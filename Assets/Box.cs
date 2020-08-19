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

    private void Update()
    {
        Debug.Log(transform.position);
    }

    public void SetActiveBall(bool flag)
    {
        ball.gameObject.SetActive(flag);
    }

    public void TargetFound()
    {
        //StartCoroutine("Move");
    }

    public void TargetLost()
    {
       // StopCoroutine("Move");
        transform.localPosition = Vector3.zero;
    }

}
