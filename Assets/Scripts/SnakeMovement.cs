using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    public PlayerDirection direction;
    private  PlayerDirection prevDir;
    bool colliderHitByRaycast;
    RaycastHit hit;



    [SerializeField] float frequency = 0.2f;
    [SerializeField] float stepLenght = 0.2f;
    [SerializeField] Transform spawnPos;
    private bool move;
    private float counter;

    // Parts to be added
    [SerializeField] private GameObject bodyPartPrefab;


    [HideInInspector]
    private List<Vector3> DeltaPosition;

    private Transform tr;

    private Rigidbody mainBody;
    private Rigidbody headBody;
    private List<Rigidbody> BodyParts; // Aca reemplazar con TDA de lista enlazada

    private bool createBodyPart;

    void Awake ()
    {
        //tr = transform;
        tr = transform; //--
        mainBody = GetComponent<Rigidbody>();
        mainBody.position = spawnPos.position; //--
        Debug.Log("pos main " + mainBody.position);
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
                BodyParts[0].position = mainBody.position;//--
                Debug.Log("Pos 0 " + BodyParts[0].position);
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

        if (createBodyPart)
        {
           GameObject newNode = Instantiate(bodyPartPrefab,BodyParts[BodyParts.Count-1].position,Quaternion.identity); // bodyparts.count - 1 change for "LAST NODE"
           // add the .next to the last part of the snake
            newNode.transform.SetParent(transform, true);
           BodyParts.Add(newNode.GetComponent<Rigidbody>());
          
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
        Debug.Log("1 Dir: " + direction);
        
        // The snake cannot move to the opposite way directly
        if (dir == PlayerDirection.UP && direction == PlayerDirection.DOWN ||
            dir == PlayerDirection.DOWN && direction == PlayerDirection.UP ||
            dir == PlayerDirection.LEFT && direction == PlayerDirection.RIGHT||
            dir == PlayerDirection.RIGHT && direction == PlayerDirection.LEFT)
        {
            return;
        }
        if (ChangeDir(dir))
        {
            direction = dir;//
            Debug.Log("2 Dir: " + direction);
        }
        
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

        //switch (target.tag)
        //{
        //    case Tags.FRUIT:
        //        target.gameObject.SetActive(false);
        //        createBodyPart = true;
        //        break;
        //    case Tags.GHOST:
        //        break;
        //    case Tags.BOX:
        //    case Tags.WALL:
                        

        //    default:
        //        break;
        //}

    }
    bool ChangeDir(PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerDirection.RIGHT:
                Debug.DrawRay(transform.position, Vector3.right * stepLenght, Color.red, 3);
                colliderHitByRaycast = Physics.Raycast(transform.position, Vector3.right, out hit, stepLenght);
                Debug.Log("Pew derecha");
                break;
            case PlayerDirection.LEFT:
                Debug.DrawRay(transform.position, Vector3.left * stepLenght, Color.red, 3);
                colliderHitByRaycast = Physics.Raycast(transform.position, Vector3.left, out hit, stepLenght);
                Debug.Log("Pew izq");
                break;
            case PlayerDirection.DOWN:
                Debug.DrawRay(transform.position, Vector3.back * stepLenght, Color.red, 3);
                colliderHitByRaycast = Physics.Raycast(transform.position, Vector3.back, out hit, stepLenght);
                Debug.Log("Pew abajo");
                break;
            case PlayerDirection.UP:
                Debug.DrawRay(transform.position, Vector3.forward * stepLenght, Color.red, 3);
                colliderHitByRaycast = Physics.Raycast(transform.position, Vector3.forward, out hit, stepLenght);
                Debug.Log("Pew arriba");
                break;
            default:
                Debug.DrawRay(transform.position, Vector3.forward * stepLenght * 3, Color.blue, 3);
                break;
        }
        return !colliderHitByRaycast || hit.collider.isTrigger;
    }


}
