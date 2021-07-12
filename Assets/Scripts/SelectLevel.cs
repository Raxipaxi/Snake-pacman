using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] Button[] nivelButtom;

    // Start is called before the first frame update
    void Start()
    {
        int nivel = PlayerPrefs.GetInt("nivel", 2);

        for (int i = 0; i < nivelButtom.Length; i++)
        {
            if (i + 2 > nivel)
                nivelButtom[i].interactable = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
