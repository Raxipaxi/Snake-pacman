using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    private Vector3 position;
    public LayerMask WALL;
    public int etiq;
    public MapNode[] Neighbors; // Nodos adyacentes
   // public [] Neighbors; // Nodos adyacentes
    public MapNode parent;

    public bool IsWall = true;


    // Start is called before the first frame update
    void Start()
    {
        position = transform.localPosition;
        CheckIsWall();
        Neighbors = GetNeighboringNodes();
    }
    void CheckIsWall()
    {
        if (!Physics.CheckSphere(position,Metrics.NODEHEADDIST/2,WALL))
        {
            IsWall = false;
        }
    }
    public MapNode[] GetNeighboringNodes()
    {
        MapNode[] NeighborList = Neighbors ;
        int index=0;
        float checkX;
        float checkZ;
        Vector3 vectorcheck;
        Collider[] colliders;

        //Check the Right
        checkX = position.x  + Metrics.NODEHEADDIST; // replace 1 with step
        checkZ = position.z;
        
        vectorcheck = new Vector3 (checkX, 4, checkZ);

        if (checkX >= 0 && checkX < GridSize.MAXX)
        {
            if (checkZ >= GridSize.MINZ && checkZ < GridSize.MAXZ)
            {
                colliders =  Physics.OverlapSphere(vectorcheck, Metrics.NODEHEADDIST / 2);// Obtiene el nodo de esa posicion
                MapNode temp = colliders[0].gameObject.GetComponent<MapNode>(); 

                if (!temp.IsWall)
                {
                    NeighborList[index] = temp;
                    index++;
                }
                
            }
        }
        //Check the Left 
        checkX = position.x - Metrics.NODEHEADDIST; // replace 1 with step
        checkZ = position.z;
        vectorcheck = new Vector3(checkX, 4, checkZ);

        if (checkX >= 0 && checkX < GridSize.MAXX)
        {
            if (checkZ >= GridSize.MINZ && checkZ < GridSize.MAXZ)
            {
                colliders = Physics.OverlapSphere(vectorcheck, Metrics.NODEHEADDIST / 2);// Obtiene el nodo de esa posicion
                MapNode temp = colliders[0].gameObject.GetComponent<MapNode>();

                if (!temp.IsWall)
                {
                    NeighborList[index] = temp;
                    index++;
                }

            }
        }
        //Check the Top 

        checkX = position.x ; // replace 1 with step
        checkZ = position.z + Metrics.NODEHEADDIST;
        vectorcheck = new Vector3(checkX, 4, checkZ);

        if (checkX >= 0 && checkX < GridSize.MAXX)
        {
            if (checkZ >= GridSize.MINZ && checkZ < GridSize.MAXZ)
            {
                colliders = Physics.OverlapSphere(vectorcheck, Metrics.NODEHEADDIST / 2);// Obtiene el nodo de esa posicion
                MapNode temp = colliders[0].gameObject.GetComponent<MapNode>();

                if (!temp.IsWall)
                {
                    NeighborList[index] = temp;
                    index++;
                }

            }
        }
        //Check the Bottom 
        checkX = position.x; // replace 1 with step
        checkZ = position.z - Metrics.NODEHEADDIST;
        vectorcheck = new Vector3(checkX, 4, checkZ);

        if (checkX >= 0 && checkX < GridSize.MAXX)
        {
            if (checkZ >= GridSize.MINZ && checkZ < GridSize.MAXZ)
            {
                colliders = Physics.OverlapSphere(vectorcheck, Metrics.NODEHEADDIST / 2);// Obtiene el nodo de esa posicion
                MapNode temp = colliders[0].gameObject.GetComponent<MapNode>();

                if (!temp.IsWall)
                {
                    NeighborList[index] = temp;
                    index++;
                }

            }
        }

        return NeighborList;
    }


}
