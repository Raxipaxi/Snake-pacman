using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Items : MonoBehaviour
{ 
    //*ESTE SCRIPT NO SE ESTA USANDO POR EL MOMENTO
    [SerializeField]
    public static int numberItem;

    public void OnTriggerEnter(Collider other) //TEST
    {
        if (other.gameObject.tag == "Player") // chequea su condicion para pasar al siguiente nivel
        {
            numberItem += 1;
            Destroy(gameObject);
        }

    }
  
    // Start is called before the first frame update
    void Start()
    {
        numberItem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Items {numberItem}");

    }
}
