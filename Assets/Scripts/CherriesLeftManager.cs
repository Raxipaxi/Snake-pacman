using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CherriesLeftManager : MonoBehaviour
{
    [SerializeField] int levelMaxCherries;     //Cantidad de Cherries que va a haber en el nivel
    [SerializeField] GameObject cherryImage;    //Prefab de la imagen
    [SerializeField] List<Transform> positions;  //Slots del panel
    [SerializeField] Image panel;                //Referencia al panel gris a la derecha del escenario
    GameObject player;                           //La referencia al player
    //ColaEstatica cherries;
    Queue<GameObject> cherries;
    public bool OnWin;
    void Start()
    {
        //cherries = new ColaEstatica(levelMaxCherries);
        OnWin = false;
        cherries = new Queue<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SnakeMovement>().OnCherryCollected.AddListener(OnCherryCollectedHandler); //Me suscribo al evento en SnakeMovement que se llama al agarrar una fruta, y cuando ocurre se activa el método
        StartCherriesQueue(); // Inicio la cola con la cantidad maxima de cherries
        UpdatePositions();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePositions(); // Actualizo las posiciones cuando saco una cherry
        if (cherries.Count == 0)
        {
            OnWin=true;
        }
    }

    void StartCherriesQueue()
    {
        for (int i = 0; i < levelMaxCherries; i++)
        {
            var temp = Instantiate(cherryImage);   // Instancio una Image de Cherry en el Canvas
            temp.transform.SetParent(panel.transform);  // Convierto el Panel del canvas en el padre de la imagen para luego ubicarlo en su slot
            cherries.Enqueue(temp);
        }
    }

    void OnCherryCollectedHandler()    // El método que está suscrito al evento OnCherryCollected, se ejecuta cuando el player recoge una básicamente
    {
        var temp = cherries.Dequeue();
        Destroy(temp);
    }

    void UpdatePositions()   // Igualo la posición de cada cherry en la cola con las posiciones que tiene el panel del canvas
    {
        int index = 0;

        foreach(GameObject cherry in cherries)
        {
            cherry.transform.localPosition = positions[index].localPosition;  
            index++;
        }
    }
}
