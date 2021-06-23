using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private CherriesLeftManager cherriesWin;
    [SerializeField]
    private SnakeMovement snakeMovement;
    private int currentLevelReset;
    [SerializeField]
    GameObject screenWin;
    [SerializeField]
    GameObject screenDefeat;
    [SerializeField]
    int nextLevel;
    [SerializeField]
    GameObject Fruit;
    [SerializeField]
    int itemsRequired; //cantidad de items o frutas para ganar

    //public static LevelManager instance;
    //Level limits
    ////X: -52.5 - 52.5
    //private float minX = -52.5f;
    //private float maxX = 52.5f;
    ////Z: -52.5   52.5
    //private float minZ = -52.5f;
    //private float maxZ = 52.5f;

    private float fruitY = 3.5f;




    // FruitGenerator
    List<GameObject> Fruits;
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
        FruitsPool();
        Time.timeScale = 1f;


    }

    void Update()
    {
        //Debug.Log("1 Frutas cant: " + GameObject.FindGameObjectsWithTag(Tags.FRUIT).Length);
        CheckFruits();     
        CheckLevelPass();
        if (snakeMovement.onDeath)
        {
            Time.timeScale = 0f;
            screenDefeat.SetActive(true);
        }
        // KeyHacks();


    }
    public void FruitsPool()
    {
        Fruits = new List<GameObject>();
        for (int i = 0; i < itemsRequired; i++)
        {
            Fruits.Add(Fruit);
           //Debug.Log("Pool " + Fruits.Count);
        }
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
    void CheckFruits()
    {
        if (Fruits.Count>0 && GameObject.FindGameObjectsWithTag(Tags.FRUIT).Length == 0)
        {
            //DestroyObject(GameObject.FindGameObjectWithTag(Tags.FRUIT).GetComponent(GameObject));
            SpawnFruit();
            Fruits.RemoveAt(Fruits.Count - 1);
            itemsRequired--;
        }
    }
    void SpawnFruit()
    {
        int spw;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                spw = Random.Range(0, SpawnPointslvl1.spawn.Length - 1); // Array de vector de level 1
                                                                             // int spw = Random.Range(0, SpawnPointslvl2.spawn.Length - 1); // Array de vector de level 2 ///
                Fruit = Instantiate(Fruits[Fruits.Count - 1], new Vector3(SpawnPointslvl1.spawn[spw].x, fruitY, SpawnPointslvl1.spawn[spw].z), Quaternion.identity);
                //Fruit = Instantiate(Fruits[Fruits.Count - 1],new Vector3(SpawnPointslvl2.spawn[spw].x, fruitY, SpawnPointslvl2.spawn[spw].z), Quaternion.identity);
                break;

            case 2:
                 spw = Random.Range(0, SpawnPointslvl2.spawn.Length - 1); // Array de vector de level 1
                                                                           
                Fruit = Instantiate(Fruits[Fruits.Count - 1], new Vector3(SpawnPointslvl2.spawn[spw].x, fruitY, SpawnPointslvl2.spawn[spw].z), Quaternion.identity);

                break;
            default:
                break;
        }


    }
    private void CheckLevelPass()
    {
       
        if (SceneManager.GetActiveScene().buildIndex == 2 && cherriesWin.OnWin) //aca lo mismo, pero sin sacar la primera condicion.
        {
            Time.timeScale = 0f;
            screenWin.SetActive(true);
            Debug.Log("GANASTE--TU--PUNTUACION--FUE--DE--(PUNTUACION)"); //TODO: ACA TENDRIA QUE IR EL SCORE
            PlayerPrefs.DeleteAll();
        }

        else   //controla si se gana 
        {
           // Debug.Log(cherriesWin.OnWin+"debugeadoo");
            if (cherriesWin.OnWin) //TODO: aca habria que hacer si la cantidad de frutas acumuladas es igual o mayor a itemsRequired. Entonces gana.
            {
                Time.timeScale = 0f;                
                PlayerPrefs.SetInt("nivel", nextLevel + 1); //se desbloquea el nivel  
                screenWin.SetActive(true);//imprime

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    screenWin.SetActive(false);
                    Time.timeScale = 1f;
                    SceneManager.LoadScene(nextLevel);

                  
                    //y resetea el numero de items agarrados 
                }


            }
        }
    }
   public void RestartLevel()
   {
        SceneManager.LoadScene(currentLevelReset);
   }

    private void KeyHacks()
    {
        NextLevel();
        ReturnMenu();
        ResetLockLevels();
        RunVictoryWithKey();
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

    private void RunVictoryWithKey()
    {
        if (Input.GetKeyDown(KeyCode.F1)) // te hace ganar el level 1
        {
            itemsRequired = 2;
        }

        if (Input.GetKeyDown(KeyCode.F2)) // te hace ganar el level 2
        {
            itemsRequired = 3;
        }
    }


}


