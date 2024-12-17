using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody platformRb;
    public Transform[] platformsPositions;
    public float speed;
    public int nextPosition = 1;

    void Update()
    {
        MovePlatfrom();
    }

    private void Start()
    {
        platformRb.transform.position = platformsPositions[0].position;
    }

    private void MovePlatfrom()
    {
        platformRb.MovePosition(Vector3.MoveTowards(platformRb.position, 
            platformsPositions[GetNextPosition()].position,
            speed * Time.deltaTime));
    }

    private int GetNextPosition()
    {
        if (platformRb.position == platformsPositions[nextPosition].position)
            if (++nextPosition == platformsPositions.Length)
                nextPosition = 0;
        return nextPosition;
    }
}