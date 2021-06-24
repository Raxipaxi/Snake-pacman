using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    
  
    GameObject player;
    [SerializeField] Text scoreText;
    
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SnakeMovement>().OnCherryCollected.AddListener(OnCherryCollectedHandler);
        player.GetComponent<SnakeMovement>().OnGetDamage.AddListener(OnGetDamageHandler);


    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                PlayerStats.Level = 1;
                break;
            case 2:
                PlayerStats.Level = 2;
                break;
        }
    }

    void OnCherryCollectedHandler()
    {
        
        PlayerStats.Score += 100;
        UpdateScore();
        
    }

    void OnGetDamageHandler()
    {
        PlayerStats.Score -= 50;
        if(PlayerStats.Score < 0)
        {
            PlayerStats.Score = 0;
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {PlayerStats.Score}"; 
        
    }
}
