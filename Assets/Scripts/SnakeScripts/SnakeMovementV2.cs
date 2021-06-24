using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementV2 : MonoBehaviour
{

    public PlayerDirection direction;


    [SerializeField] float frequency = 0.2f;
    [SerializeField] float stepLenght = 0.2f;
    private bool move;
    private float counter;

    // Parts to be added
    [SerializeField] private GameObject bodyPartPrefab;
    //[SerializeField] private List<Rigidbody> BodyParts;


    [HideInInspector]
    private List<Vector3> DeltaPosition;

    private Transform tr;

    private Rigidbody mainBody;
    private Rigidbody headBody;

    private SnakeBody BodyParts;


    private bool createBodyPart;

    void Awake()
    {
        tr = transform;
        mainBody = GetComponent<Rigidbody>();
        InitSnakeParts();
        InitPlayer();

        headBody = BodyParts.GetFirst().GetPart();
        DeltaPosition = new List<Vector3>() // Must be in the same order as PlayerDirection enum
        {
            new Vector3(-stepLenght,0f,0f ), // -x Left
            new Vector3(0f,0f,stepLenght ), //+z Up
            new Vector3(stepLenght,0f,0f ), // +x Right
            new Vector3(0f,0f,-stepLenght ), // -z Down
            
        };
    }
    // Update is called once per frame
    void Update()
    {
        CheckMovFrequency();
        if (move)
        {
            move = false;
            Move();
        };
    }
    void InitSnakeParts()
    {

        BodyParts = new SnakeBody();
        BodyParts.Initialize();
        BodyParts.Add(new Node(tr.GetChild(0).GetComponent<Rigidbody>()));
        BodyParts.Add(new Node(tr.GetChild(1).GetComponent<Rigidbody>()));
        BodyParts.Add(new Node(tr.GetChild(2).GetComponent<Rigidbody>()));

    }
    void InitPlayer()
    {  // initiate the position of the NODES and tail
        switch (direction)
        {
            case PlayerDirection.LEFT:

                BodyParts.GetPart(1).position = BodyParts.GetPart(0).position + new Vector3(Metrics.NODEHEADDIST, 0f, 0f);
                BodyParts.GetPart(2).position = BodyParts.GetPart(1).position + new Vector3(Metrics.NODESIZE, 0f, 0f);
                break;
            case PlayerDirection.UP:
                BodyParts.GetPart(1).position = BodyParts.GetPart(0).position - new Vector3(0f, 0f, Metrics.NODEHEADDIST);
                BodyParts.GetPart(2).position = BodyParts.GetPart(1).position - new Vector3(0f, 0f, Metrics.NODESIZE);

                break;
            case PlayerDirection.RIGHT:
                BodyParts.GetPart(1).position = BodyParts.GetPart(0).position - new Vector3(Metrics.NODEHEADDIST, 0f, 0f);
                BodyParts.GetPart(2).position = BodyParts.GetPart(1).position - new Vector3(Metrics.NODESIZE, 0f, 0f);
                break;
            case PlayerDirection.DOWN:
                BodyParts.GetPart(1).position = BodyParts.GetPart(0).position + new Vector3(0f, 0f, Metrics.NODEHEADDIST);
                BodyParts.GetPart(2).position = BodyParts.GetPart(1).position + new Vector3(0f, 0f, Metrics.NODESIZE);
                break;
            default:
                break;
        }
    }

    void Move()
    {
        Vector3 dPosition = DeltaPosition[(int)direction]; // gives the direction 

        Vector3 parentPos = headBody.transform.position;
        Vector3 prevPos;

        mainBody.position = mainBody.position + dPosition;
        headBody.position = headBody.position + dPosition;

         for (int i = 1; i < BodyParts.GetCount(); i++)
        {
            prevPos = BodyParts.GetPart(i).transform.position;
            BodyParts.GetPart(i).position = parentPos;
            parentPos = prevPos;
        }

        if (createBodyPart)
        {
            GameObject newNode = Instantiate(bodyPartPrefab,BodyParts.GetPart(BodyParts.GetCount()-1).position,Quaternion.identity); // bodyparts.count - 1 change for "LAST NODE"
                                                                                                                            // add the .next to the last part of the snake
            newNode.transform.SetParent(transform, true);
            BodyParts.Add(new Node(newNode.GetComponent<Rigidbody>()));

            createBodyPart = false;
        }
    }

    void CheckMovFrequency()
    {
        counter += Time.deltaTime;

        if (counter >= frequency)
        {
            counter = 0f;
            move = true;
        }
    }

    public void SetDirection(PlayerDirection dir)
    {
        // The snake cannot move to the opposite way directly
        if (dir == PlayerDirection.UP && direction == PlayerDirection.DOWN ||
            dir == PlayerDirection.DOWN && direction == PlayerDirection.UP ||
            dir == PlayerDirection.LEFT && direction == PlayerDirection.RIGHT ||
            dir == PlayerDirection.RIGHT && direction == PlayerDirection.LEFT)
        {
            return;
        }
        direction = dir;
        ForceMove();
    }
    void ForceMove()
    {
        counter = 0;
        move = false;
        Move();
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == Tags.FRUIT)
        {

            target.gameObject.SetActive(false);
            createBodyPart = true;
        }


    }

}
