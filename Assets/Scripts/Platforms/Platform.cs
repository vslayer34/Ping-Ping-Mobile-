using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    // referance to the input manager
    [SerializeField] protected InputManager inputManager;

    // a variable to store the touch position
    protected Vector3 touchPosition;

    // determine if the platform is activly touched or not
    protected bool isActive;

    protected float screenLimits = 4.0f;

    /// <summary>
    /// get if the finger is touching the platform or not
    /// and if so set the platform to active
    /// </summary>
    protected void IsPlatformActiveNow()
    {
        // the detection limit of the platform position and the touch position
        float detectionLimitX = 1.5f;
        float detectionLimitY = 0.4f;

        if (inputManager.IsActiveTouch && Mathf.Abs((touchPosition.x - transform.position.x)) < detectionLimitX
            && inputManager.IsActiveTouch && Mathf.Abs((touchPosition.y - transform.position.y)) < detectionLimitY)
        {
            isActive = true;
        }
        
        // keep the platform active during the touch phase
        // untill the player lift his/her finger
        if (inputManager.IsFingerLifted)
        {
            isActive = false;
        }
    }

    /// <summary>
    /// The platform follows the touch position
    /// </summary>
    /// <param name="isActive">whether the the player touching the platform or not</param>
    protected void Move()
    {
        // check if the platform is being touched
        IsPlatformActiveNow();

        // and if so move it with the finger
        if (isActive)
        {
            Vector3 newPosition;
            // prevent it from going over the border
            if (touchPosition.y >= screenLimits)
            {
                newPosition = new Vector2(transform.position.x, screenLimits);
            }
            else if (touchPosition.y <= -screenLimits)
            {
                newPosition = new Vector2(transform.position.x, -screenLimits);
            }
            else
            {
                newPosition = new Vector2(transform.position.x, touchPosition.y);
            }
            
            transform.position = newPosition;
        }
    }
}
