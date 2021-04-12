using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SnakeMovement : MonoBehaviour
{

    public PlayerDirection direction;


    [SerializeField] float frequency = 0.2f;
    [SerializeField] float stepLenght = 0.2f;
    private bool move;
    private float counter;

    // Parts to be add
    [SerializeField] private GameObject bodyPartPrefab;
    //[SerializeField] private List<Rigidbody> BodyParts;


    [HideInInspector]
    private List<Vector3> DeltaPosition;

    private Transform tr;

    private Rigidbody mainBody;
    private Rigidbody headBody;
    private List<Rigidbody> BodyParts;

    // Aca reemplazar con TDA de push de Pila
    private bool createBodyPart;

    void Awake ()
    {
        tr = transform;
        mainBody = GetComponent<Rigidbody>();  
        InitSnakeParts();
        InitPlayer();
        headBody = BodyParts[0];
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

    void FixUpdate()
    {

    }
    void InitSnakeParts()
    {
        BodyParts = new List<Rigidbody>();
        BodyParts.Add(tr.GetChild(0).GetComponent<Rigidbody>());
        BodyParts.Add(tr.GetChild(1).GetComponent<Rigidbody>());
        BodyParts.Add(tr.GetChild(2).GetComponent<Rigidbody>()); 
    }
    void InitPlayer()
    {  // initiate the position of the NODES and tail
        switch (direction)
        {
            case PlayerDirection.LEFT:
                BodyParts[1].position = BodyParts[0].position + new Vector3(Metrics.NODEHEADDIST, 0f, 0f);
                BodyParts[2].position = BodyParts[1].position + new Vector3(Metrics.NODESIZE, 0f, 0f);
                break;
            case PlayerDirection.UP:
                BodyParts[1].position = BodyParts[0].position - new Vector3(0f, 0f, Metrics.NODEHEADDIST);
                BodyParts[2].position = BodyParts[1].position - new Vector3(0f, 0f, Metrics.NODESIZE);
                break;
            case PlayerDirection.RIGHT:
                BodyParts[1].position = BodyParts[0].position - new Vector3(Metrics.NODEHEADDIST, 0f, 0f);
                BodyParts[2].position = BodyParts[1].position - new Vector3(Metrics.NODESIZE, 0f, 0f);
                break;
            case PlayerDirection.DOWN:
                BodyParts[1].position = BodyParts[0].position + new Vector3(0f, 0f, Metrics.NODEHEADDIST);
                BodyParts[2].position = BodyParts[1].position + new Vector3(0f, 0f, Metrics.NODESIZE);
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

        for (int i = 1; i < BodyParts.Count; i++)
        {
            prevPos = BodyParts[i].transform.position;
            BodyParts[i].position = parentPos;
            parentPos = prevPos; 
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
            dir == PlayerDirection.LEFT && direction == PlayerDirection.RIGHT||
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
}
