using UnityEngine;

public class MainPlatform : Platform
{
    [SerializeField] private Transform holdingPoint;
    [SerializeField] private Transform ballPrefab;

    private Transform spawnedBall;

    private void Start()
    {
        SetUpBall();
        Invoke("LaunchTheBall", 1.0f);
    }

    private void Update()
    {
        touchPosition = inputManager.ActiveTouchPosition;
        Move(JoystickDirectionY);
    }


    /// <summary>
    /// Spawn the ball at the start of the game
    /// </summary>
    private void SetUpBall()
    {
        spawnedBall = Instantiate(ballPrefab, holdingPoint);
        spawnedBall.localPosition = Vector2.zero;
    }


    /// <summary>
    /// Release the ball from the platform and launch it
    /// </summary>
    private void LaunchTheBall()
    {
        spawnedBall.TryGetComponent(out BallBehaviour ballScript);

        // check if the platform has a ball or not
        if (holdingPoint.childCount != 0)
        {
            // release it from holding area and shoot the ball
            spawnedBall.parent = null;
            ballScript.AddLaunchForce();
        }
    }
}
