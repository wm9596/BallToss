using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Ball ball;
    
    new Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
        ball = FindObjectOfType<Ball>();
    }

    //이미지 타겟이 이미지를 인식하면 공을 활성화 시킴
    public void SetActiveBall(bool flag)
    {
        ball.gameObject.SetActive(flag);
    }

}
