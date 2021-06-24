using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    int score;
    RankingManager rankingManager;
    GameObject player;
    [SerializeField] Text scoreText;
    
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SnakeMovement>().OnCherryCollected.AddListener(OnCherryCollectedHandler);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCherryCollectedHandler()
    {
        score += 100;
        UpdateScore();
        rankingManager.StoredScore += score;
        
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {score}"; 
        
    }
}
