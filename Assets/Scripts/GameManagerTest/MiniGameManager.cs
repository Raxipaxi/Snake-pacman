using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    ScoreManager scoreManager;
    // Start is called before the first frame update

    public int TotalRecordLlegado { get; private set; }

    void Start()
    {
        TotalRecordLlegado = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TotalRecordLlegado++;
            Debug.Log($"Tu record es {TotalRecordLlegado}");
        }
    }
}
