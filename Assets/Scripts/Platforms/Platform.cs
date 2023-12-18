using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public abstract class Platform : MonoBehaviour
{
    // referance to the input manager
    [SerializeField] protected InputManager inputManager;

    // a variable to store the touch position
    protected Vector3 touchPosition;

    // screen joystick 
    [SerializeField]
    protected Joystick _joyStickDirection;

    [SerializeField]
    protected float speed;

    // determine if the platform is activly touched or not
    protected bool isActive;

    protected float screenLimits = 4.0f;

    protected PlatformAction platformAction;

    protected static int instanceNumber;

    protected static Rigidbody2D _rb;


    //----------------------------------------------------------------------------------
    /// <summary>
    /// get the joystick y direction normalized
    /// </summary>
    public float JoystickDirectionY { get => _joyStickDirection.Direction.y; }


    /// <summary>
    /// get if the finger is touching the platform or not
    /// and if so set the platform to active
    /// </summary>
    protected void IsPlatformActiveNow()
    {
        

        /*
        // the detection limit of the platform position and the touch position
        float detectionLimitX = 1.5f;
        float detectionLimitY = 0.4f;

        if (inputManager.IsActiveTouch && Mathf.Abs((touchPosition.x - transform.position.x)) < detectionLimitX
            && inputManager.IsActiveTouch && Mathf.Abs((touchPosition.y - transform.position.y)) < detectionLimitY)
        {
            isActive = true;
            Debug.Log($"{gameObject.name} is Active");
        }
        
        // keep the platform active during the touch phase
        // untill the player lift his/her finger
        if (inputManager.IsFingerLifted)
        {
            isActive = false;
            Debug.Log($"{gameObject.name} is Inactive");
        }
        */
    }
    
    /*
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
            

            
            
            //foreach (var slot in InputManager.touchsDict)
            //{
            //    int i = 0;
            //    Debug.Log($"Loop iteration: {i}");
            //    i++;

            //    Vector3 newPosition;
            //    // prevent it from going over the border
            //    if (slot.Value.y >= screenLimits)
            //    {
            //        newPosition = new Vector2(transform.position.x, screenLimits);
            //    }
            //    else if (slot.Value.y <= -screenLimits)
            //    {
            //        newPosition = new Vector2(transform.position.x, -screenLimits);
            //    }
            //    else
            //    {
            //        newPosition = new Vector2(transform.position.x, slot.Value.y);
            //    }

            //    transform.position = newPosition;
                
            //}
            
            
        }
    }
    */



    protected void Move(float inputDirection)
    {
        float movementDirection = inputDirection * Time.deltaTime * speed;
        Vector2 movementVector = new Vector3(0.0f, movementDirection, 0.0f);
        transform.Translate(movementVector);

        //_rb.position += movementVector;
        //Debug.Log("I'm Being called");
    }
    
}
