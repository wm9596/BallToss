using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform resetTr;

    public float xPower = 10, yPower = 10;

    public float resetDist = 10;

    private Camera ARCam;

    new private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        ARCam = Camera.main;
    }

    private void Update()
    {
        //공이 카메라로부터 일정거리 이상 떨어지면 위치 초기화
        if ((ARCam.transform.position-transform.position).sqrMagnitude > resetDist*resetDist)
        {
            BallReset();
        }
    }

    private void OnEnable()
    {
        //리셋버튼 클릭시 공 위치도 초기화 하기 위한 이벤트 연결
        GameManager.instance.GameReset += BallReset;
    }

    private void OnDisable()
    {
        GameManager.instance.GameReset -= BallReset;
    }

    private void OnMouseDown()
    {
        //공 터치시 대각선 방향으로 힘을 가해 날림
        if (rigidbody.velocity == Vector3.zero)
        {
            transform.SetParent(null);
            rigidbody.AddForce(resetTr.transform.forward * xPower + resetTr.transform.up * yPower);
            rigidbody.useGravity = true;
        }
    }

    //공의 위치 초기화
    private void BallReset()
    {
        transform.SetParent(ARCam.transform);
        transform.position = resetTr.position;
        transform.rotation = resetTr.rotation;
        rigidbody.useGravity = false;
        rigidbody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision coll)
    {
        //충돌체에 닿았을 때 닿은 물체가 상자면 점수 획득
        if (coll.collider.CompareTag("Goal"))
        {
            GameManager.instance.GetSocre();
        }
        //닿은 물체에 상관없이 공위치 초기화
        BallReset();
    }
}
