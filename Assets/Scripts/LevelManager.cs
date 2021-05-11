using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    //Level limits
    //X: -52.5 - 52.5
    private float minX = -52.5f;
    private float maxX =  52.5f;
    //Z: -52.5   52.5
    private float minZ = -52.5f;
    private float maxZ = 52.5f;

    private float fruitY = 3.5f;


    /* Va a instanciar todo en el nivel
     * 
     * Resetear a la snake cuando muera
     * 
     * controlar que siga habiendo vidas
     * 
     * 
     * controla si se gana o pierde
     * 
     * 
     * Crea enemigos
     * 
     */

    void Awake()
    {
        MakeInstance();
    }

    // Update is called once per frame
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
} //end
