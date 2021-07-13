using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("SALIENDO DEL JUEGO");
        Application.Quit();
    }

    public void ReturnScoreboard()
    {

        SceneManager.LoadScene(4);
    }
    public void ReturnMenu()
    {
       
        SceneManager.LoadScene(0);
    }
    public void NextLvl()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex = sceneIndex + 1;
        SceneManager.LoadScene(sceneIndex);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
