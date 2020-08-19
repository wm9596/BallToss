using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform resetTr;

    public float xPower = 10, yPower = 10;

    private Camera ARCam;

    new private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        ARCam = Camera.main;
    }

    private void Update()
    {
        if (transform.position.y < -8)
        {
            BallReset();
        }
    }

    private void OnEnable()
    {
        GameManager.instance.GameReset += BallReset;
    }

    private void OnDisable()
    {
        GameManager.instance.GameReset -= BallReset;
    }

    private void OnMouseDown()
    {
        transform.SetParent(null);
        rigidbody.AddForce(resetTr.transform.forward * xPower + resetTr.transform.up * yPower);
        rigidbody.useGravity = true;
    }

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
        if (coll.collider.CompareTag("Goal"))
        {
            GameManager.instance.GetSocre();
        }

        BallReset();
    }
}
