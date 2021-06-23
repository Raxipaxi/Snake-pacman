using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject grid;
    MapNode[] NodeGrid;
    GrafoMA graph;

    // Start is called before the first frame update
    void Start()
    {
        NodeGrid = grid.GetComponentsInChildren<MapNode>();
        CheckNeigbors();
        graph = new GrafoMA();
        graph.InicializarGrafo();
        LoadGraph();
        print("blah");
    }

    void LoadGraph()
    {
        for (int i = 0; i < NodeGrid.Length; i++)                                        // Recorro todos los nodos
        {
            graph.AgregarVertice(NodeGrid[i].etiq); 
           // print("Agregado " + NodeGrid[i].etiq);
        }
        for (int i = 0; i < NodeGrid.Length; i++)
        {
           // print("Nodo " + NodeGrid[i].etiq);
            for (int j = 0; j < NodeGrid[i].Neighbors.Length && !(NodeGrid[i].Neighbors[j] == null); j++)
            {
                graph.AgregarArista(NodeGrid[i].etiq, NodeGrid[i].Neighbors[j].etiq, 1); // Agrego todos los vecinos 
                //print("Vecino " + NodeGrid[i].Neighbors[j].etiq);
            }
        }
    }

    void CheckNeigbors()
    {
        for (int i = 0; i < NodeGrid.Length; i++)
        {
            NodeGrid[i].GetNeighboringNodes(NodeGrid);
        }
    }
}
