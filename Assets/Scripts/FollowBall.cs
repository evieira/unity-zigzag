using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    [SerializeField]
    private Transform ball;
    private Vector3 distance;
    private Vector3 position;
    private Vector3 targetPosition;
    private float lerpValue = 1;
    void Start()
    {
        distance = ball.position - transform.position;
    }

    void LateUpdate()
    {
        if(BallController.gameOver)
            return;
        
        FollowFunction();
    }

    private void FollowFunction()
    {
        position = transform.position;
        targetPosition = ball.position - distance;
        position = Vector3.Lerp(position, targetPosition, lerpValue);
        transform.position = position;
    }
}
