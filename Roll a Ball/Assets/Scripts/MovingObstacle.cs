using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

    Vector3 velocity = new Vector3(0.0f, 6.0f, 0.0f);
    float floorHeight = 0.0f;
    float sleepThreshold = 0.05f;
    float gravity = -9.8f;
    private int score;

    void Start()
    {
        transform.position = new Vector3(7.6f, 0.5f, 10.1f);
    }

    void FixedUpdate()
    {
        if (velocity.magnitude > sleepThreshold || transform.position.y > floorHeight)
        {
            velocity += new Vector3(0.0f, gravity * Time.fixedDeltaTime, 0.0f);
        }

        transform.position += velocity * Time.fixedDeltaTime;
        if (transform.position.y <= floorHeight)
        {
            transform.position = new Vector3(7.6f, floorHeight, 10.1f);
            velocity.y = -velocity.y;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MovingObstacles"))
        {
            other.gameObject.SetActive(false);
            // count = count + 1; // I commented this out because I am not going to use it for the enemy.
            score = score - 1; // this removes 1 from the score
            SetAllText();
        }
    }

    private void SetAllText()
    {
        throw new NotImplementedException();
    }
}
