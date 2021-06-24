using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject grid;
    public MapNode[] NodeGrids;
    public GrafoMA graph;

    // Start is called before the first frame update
    void Start()
    {
        NodeGrids = grid.GetComponentsInChildren<MapNode>();
        CheckNeigbors();
        graph = new GrafoMA();
        graph.InicializarGrafo();
        LoadGraph();
    }

    void LoadGraph()
    {
        for (int i = 0; i < NodeGrids.Length; i++)                                        // Recorro todos los nodos
        {
            graph.AgregarVertice(NodeGrids[i].etiq); 
           // print("Agregado " + NodeGrid[i].etiq);
        }
        for (int i = 0; i < NodeGrids.Length; i++)
        {
           // print("Nodo " + NodeGrid[i].etiq);
            for (int j = 0; j < NodeGrids[i].Neighbors.Length && !(NodeGrids[i].Neighbors[j] == null); j++)
            {
                graph.AgregarArista(NodeGrids[i].etiq, NodeGrids[i].Neighbors[j].etiq, 1); // Agrego todos los vecinos 
                //print("Vecino " + NodeGrid[i].Neighbors[j].etiq);
            }
        }
    }
    public GrafoMA GetGraph()
    {
        return graph;
    }
    void CheckNeigbors()
    {
        for (int i = 0; i < NodeGrids.Length; i++)
        {
            NodeGrids[i].GetNeighboringNodes(NodeGrids);
        }
    }
}
