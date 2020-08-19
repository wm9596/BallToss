using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action GameReset;

    public Text scoreText;


    private int score = 0;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = $"Score : {score}";
        }


    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetSocre()
    {
        Score += 100;
    }

    public void ReSetGame()
    {
        GameReset?.Invoke();
        Score = 0;
    }
}
