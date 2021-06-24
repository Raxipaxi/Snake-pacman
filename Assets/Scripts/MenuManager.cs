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

        SceneManager.LoadScene(3);
    }
    public void ReturnMenu()
    {
       
        SceneManager.LoadScene(0);
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
