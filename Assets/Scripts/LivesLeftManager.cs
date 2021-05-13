using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LivesLeftManager : MonoBehaviour
{
    [SerializeField] int initialLives = 3;     //Cantidad de vidas iniciales
    [SerializeField] GameObject snakePartImage;    //Prefab de la imagen
    [SerializeField] List<Transform> positions;  //Slots del panel
    [SerializeField] Image panel;                //Referencia al panel gris a la derecha del escenario
    GameObject player;                           //La referencia al player
    //ColaEstatica cherries;
    Stack<GameObject> lives;
    void Start()
    {
        lives = new Stack<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SnakeMovement>().OnCherryCollected.AddListener(OnCherryCollectedHandler);
        player.GetComponent<SnakeMovement>().OnGetDamage.AddListener(OnGetDamageHandler);
       // StartLivesStack();

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePositions();
    }

    /*void StartLivesStack()
    {
        for(int i = 0; i < initialLives; i++)
        {
            var temp = Instantiate(snakePartImage);
            temp.GetComponent<Image>().color = Color.red;
            //set parent
            lives.Push(temp);
        }
    }
    */
    void OnCherryCollectedHandler()
    {
        var newLife = Instantiate(snakePartImage);
        newLife.transform.SetParent(panel.transform);
        lives.Push(newLife);
    }
    void OnGetDamageHandler()
    {
        if (lives.Count > 0) 
        { 
        var newLife = lives.Pop();
        Destroy(newLife);
        }
    }

    void UpdatePositions()
    {
        int index = 0;
        foreach (GameObject life in lives)
        {
            life.transform.localPosition= positions[index].localPosition;
            index++;
        }
    }

}
