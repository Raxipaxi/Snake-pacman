using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class GhostMovement2 : MonoBehaviour
{
    public Grid grid;
    public int follow = 10;
    public int dijkstraRepeat=1;
    public GameObject snakePlayer;
    Vector3 snakePos;
    [SerializeField] float frequency = 0.2f;
    private float counter;
    public Vector3[] enemyPath;
    public int[] pathEtiq;
    int indexStep;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ItsDijkstraTime", 0.1f,dijkstraRepeat);
    }

    void ItsDijkstraTime()
    {
        snakePos = GameObject.Find(snakePlayer.name).transform.position;

        int origin = SearchNodeEtiq(transform.position);
        int destiny = SearchNodeEtiq(snakePos); // Busca el nodo que corresponde a ese position
        
        if (origin != 0 && destiny != 0)
        {
            Dijkstra.AlgDijkstra(grid.GetGraph(), origin);

            string pattern = ",";
            var aux = Dijkstra.nodos[destiny - 1];
            string[] Sway = Regex.Split(Dijkstra.nodos[destiny-1], pattern); 

            int[] way = new int[Sway.Length];
            enemyPath = new Vector3[way.Length];
            pathEtiq = new int[way.Length];
            int pathI = 0;

 
            for (int i = 0; i < way.Length - 1; i++)
            {    
                way[i] = int.Parse(Sway[i]);
                
                for (int j = 0; j < grid.NodeGrids.Length; j++)
                {
                    if (grid.NodeGrids[j].etiq == way[i])
                    {
                        enemyPath[pathI] = grid.NodeGrids[j].GetPosition();
                        pathEtiq[pathI] = grid.NodeGrids[j].etiq;
                        pathI++;
                    }
                }
            }
            indexStep = 0;
        }
    }

    int SearchNodeEtiq(Vector3 pos)
    {
        foreach (MapNode node in grid.NodeGrids)
        {
            if (pos.x == node.GetPosition().x && pos.z == node.GetPosition().z)
            {
                return node.etiq;
            }
        }
        return 0;
    }

    void Update()
    {
            counter += Time.deltaTime;
            Vector3 currentPos;

        if (counter > frequency)
        {
            if (indexStep < enemyPath.Length-1 && enemyPath.Length < follow)
            {
                //print("Nodo " + pathEtiq[indexStep] + " " + enemyPath[indexStep]);
                currentPos = enemyPath[indexStep];
                this.transform.position = new Vector3(currentPos.x, 5.5f, currentPos.z);
                indexStep++;
                counter = 0;
            }
        }

    }
}
