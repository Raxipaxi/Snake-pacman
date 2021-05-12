using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentLevelReset;
    [SerializeField]
    GameObject screenWin; 
    [SerializeField]
    int nextLevel;
    [SerializeField]
    int itemsRequired;
    
    public static LevelManager instance;
    //Level limits
    //X: -52.5 - 52.5
    private float minX = -52.5f;
    private float maxX =  52.5f;
    //Z: -52.5   52.5
    private float minZ = -52.5f;
    private float maxZ = 52.5f;

    private float fruitY = 3.5f;


    /* 
    * controlar que siga habiendo vidas
    * 
    * 
    * controla si se gana o pierde
    * 
    * 
    * Crea enemigos
    * 
    */

    void Start()
    {
        #region Test
        currentLevelReset = SceneManager.GetActiveScene().buildIndex; 
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
#endregion
    }


    void MakeInstance()
    {
        if (instance == null)
        {
        RestartLevel(); //  Resetea a la snake cuando muere
        CheckLevelPass(); //controla si se gana o pierde

        KeyHacks(); //test

        }
    public void PlayLevel(string level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level); // Va a instanciar todo en el nivel
    }
    public void LockLevels()
    {
        PlayerPrefs.DeleteAll();
    }
    private void CheckLevelPass()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && Items.numberItem >= itemsRequired)
        {
            Time.timeScale = 0f;
            screenWin.SetActive(true);
            Debug.Log("GANASTE--TU--PUNTUACION--FUE--DE--(PUNTUACION)"); //TODO: ACA TENDRIA QUE IR EL SCORE
            PlayerPrefs.DeleteAll();
        }

        else   //controla si se gana 
        {
            if (Items.numberItem >= itemsRequired)
            {
                Time.timeScale = 0f;
                PlayerPrefs.SetInt("nivel", nextLevel + 1); //se desbloquea el nivel  
                screenWin.SetActive(true);//imprime

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Time.timeScale = 1f;
                    SceneManager.LoadScene(nextLevel);
                    Items.numberItem = 0; //y resetea el numero de items agarrados 
                }


            }
        }
    }  
    private void RestartLevel()
    {
        // Resetea a la snake cuando muera
        if (Input.GetKeyDown(KeyCode.R)) //Si muere
        {
            SceneManager.LoadScene(currentLevelReset);
        }
    }








    private void KeyHacks()
    {
        NextLevel();
        ReturnMenu();
        ResetLockLevels();
    }
    private void NextLevel()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(nextLevel);
            PlayerPrefs.SetInt("nivel", nextLevel + 1);
        }
    }

    private void ReturnMenu()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void ResetLockLevels()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
        }
    }

   
}

