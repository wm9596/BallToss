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
            //점수가 변경됐을 때 UI에 표시되는 값을 갱신함
            score = value;
            scoreText.text = $"Score : {score}";
        }
        
    }

    void Awake()
    {
        //싱글톤 인스턴스 생성
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
        //리셋버튼 클릭시 이벤트 발생
        GameReset?.Invoke();
        Score = 0;
    }
}
