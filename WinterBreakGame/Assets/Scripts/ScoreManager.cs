﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private Text scoreText;
    public static int score = 0;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        score = 0;
        UpdateScore();
	}
	
	// Update is called once per frame

    public void AddPoints(int points)
    {
        score += points;
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "" +  score;
    }
}
