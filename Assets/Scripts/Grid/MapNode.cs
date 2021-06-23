using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    public Vector3 position;
    public LayerMask WALL;
    public int etiq;
    public MapNode[] Neighbors; // Nodos adyacentes
                                // public [] Neighbors; // Nodos adyacentes
    public MapNode parent;

    public bool IsWall = false;



    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;

       // CheckIsWall();
    }
    //void CheckIsWall()
    //{
    //    if (!Physics.CheckSphere(position, Metrics.NODEHEADDIST / 4, WALL))
    //    {
    //        IsWall = false;
    //    }
    //}
    public void GetNeighboringNodes(MapNode[] NodeGrid)
    {
        int index = 0;

        if (IsWall)
        {
            return;
        }
        for (int i = 0; i < NodeGrid.Length; i++)// busco posibles vecinos
        {
            int temEtiq = NodeGrid[i].etiq;
            if (!NodeGrid[i].IsWall)
            {
                if (temEtiq == etiq + 1)                //Right
                {
                    if (temEtiq < 225 && !(etiq % 15 == 0)) // menos que la maxima y que etiq no sea del borde derecho
                    {
                        Neighbors[index] = NodeGrid[i];
                        index++;
                    }
                }
                if (temEtiq == etiq - 1)            //Left
                {
                    if (temEtiq > 0 && !((etiq - 1) % 15 == 0)) // mayor a 0 y que etiq no sea del borde izquierdo
                    {
                        Neighbors[index] = NodeGrid[i];
                        index++;
                    }
                }
                if (temEtiq == etiq + 15)           // Top
                {
                    Neighbors[index] = NodeGrid[i];
                    index++;
                }
                if (temEtiq == etiq - 15)          // Bot
                {
                    Neighbors[index] = NodeGrid[i];
                    index++;
                }
            }
            
        }
        
    }
    public Vector3 GetPosition()
    {
        return position;
    }
    //public MapNode[] GetNeighboringNodes(MapNode[] NodeGrid)
    //{
    //    MapNode[] NeighborList = Neighbors ;
    //    int index=0;
    //    float checkX;
    //    float checkZ;
    //   ;
    //    Collider[] colliders;

    //    //Check the Right
    //    checkX = position.x  + Metrics.NODEHEADDIST; // replace 1 with step
    //    checkZ = position.z;

    //    vectorcheck = new Vector3 (checkX, 4, checkZ);
    //    print("Right" + vectorcheck);
    //    OnDrawGizmos();

    //    if (checkX >= 0 && checkX < GridSize.MAXX)
    //    {
    //        if (checkZ >= GridSize.MINZ && checkZ < GridSize.MAXZ)
    //        {
    //            colliders =  Physics.OverlapSphere(vectorcheck, Metrics.NODEHEADDIST / 4);// Obtiene el nodo de esa posicion
    //            MapNode temp = colliders[0].gameObject.GetComponent<MapNode>();


    //            if (!temp.IsWall)
    //            {
    //                NeighborList[index] = temp;
    //                index++;
    //            }

    //        }
    //    }
    //    //Check the Left 
    //    checkX = position.x - Metrics.NODEHEADDIST; // replace 1 with step
    //    checkZ = position.z;
    //    vectorcheck = new Vector3(checkX, 4, checkZ);
    //    print("Left" + vectorcheck);
    //    OnDrawGizmos();

    //    if (checkX >= 0 && checkX < GridSize.MAXX)
    //    {
    //        if (checkZ >= GridSize.MINZ && checkZ < GridSize.MAXZ)
    //        {
    //            colliders = Physics.OverlapSphere(vectorcheck, Metrics.NODEHEADDIST / 4);// Obtiene el nodo de esa posicion
    //            MapNode temp = colliders[0].gameObject.GetComponent<MapNode>();

    //            if (!temp.IsWall)
    //            {
    //                NeighborList[index] = temp;
    //                index++;
    //            }

    //        }
    //    }
    //    //Check the Top 
    //    checkX = position.x ; // replace 1 with step
    //    checkZ = position.z + Metrics.NODEHEADDIST;
    //    vectorcheck = new Vector3(checkX, 4, checkZ);
    //    print("Top" + vectorcheck);
    //    OnDrawGizmos();

    //    if (checkX >= 0 && checkX < GridSize.MAXX)
    //    {
    //        if (checkZ >= GridSize.MINZ && checkZ < GridSize.MAXZ)
    //        {
    //            colliders = Physics.OverlapSphere(vectorcheck, Metrics.NODEHEADDIST / 4);// Obtiene el nodo de esa posicion
    //            MapNode temp = colliders[0].gameObject.GetComponent<MapNode>();

    //            if (!temp.IsWall)
    //            {
    //                NeighborList[index] = temp;
    //                index++;
    //            }
    //        }
    //    }
    //    //Check the Bottom 
    //    checkX = position.x; // replace 1 with step
    //    checkZ = position.z - Metrics.NODEHEADDIST;
    //    vectorcheck = new Vector3(checkX, 4, checkZ);
    //    print("Bot" + vectorcheck);
    //    OnDrawGizmos();

    //    if (checkX >= 0 && checkX < GridSize.MAXX)
    //    {
    //        if (checkZ >= GridSize.MINZ && checkZ < GridSize.MAXZ)
    //        {
    //            colliders = Physics.OverlapSphere(vectorcheck, Metrics.NODEHEADDIST /4);// Obtiene el nodo de esa posicion
    //            MapNode temp = colliders[0].gameObject.GetComponent<MapNode>();

    //            if (!temp.IsWall)
    //            {
    //                NeighborList[index] = temp;
    //                index++;
    //            }
    //        }
    //    }

    //    return NeighborList;
    //}
}
