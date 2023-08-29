using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMCameraMove : MonoBehaviour
{
    public float Tspeed = 0.1f;
    float speed = 5f;
    public Transform controller;
    
    void Awake()
    {
        transform.position = new Vector3(0, 0, -10);
    }


    void Update()
    {
        transform.position = Vector3.LerpUnclamped(transform.position, controller.position, speed * Time.deltaTime);
    }
}
