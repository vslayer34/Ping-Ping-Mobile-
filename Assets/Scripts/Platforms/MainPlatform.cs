using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlatform : Platform
{
    [SerializeField] private Transform holdingPoint;
    [SerializeField] private Transform ballPrefab;


    private void Start()
    {
        SetUpBall();
    }

    private void Update()
    {
        touchPosition = inputManager.ActiveTouchPosition;
        Move();
    }


    /// <summary>
    /// Spawn the ball at the start of the game
    /// </summary>
    private void SetUpBall()
    {
        Instantiate(ballPrefab, holdingPoint);
        ballPrefab.localPosition = Vector2.zero;
    }
}
