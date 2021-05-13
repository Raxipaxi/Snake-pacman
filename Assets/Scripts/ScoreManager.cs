using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    int score;
    GameObject player;
    [SerializeField] Text scoreText;

    void Start()
    {
        score = 0;
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
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {score}"; 
    }
}
