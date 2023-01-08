using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotateAndFloat : MonoBehaviour
{
    private float rotateSpeed = 20;
    private float floatFrequency = 1, floatAmplitude = .25f;
    public Vector3 startPos;

    void Awake()
    {
        startPos = transform.position;
    }

    void Update()
    {
        //Make sure you are using the right parameters here
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency) * floatAmplitude;

        transform.position = tempPos;
    }
}
