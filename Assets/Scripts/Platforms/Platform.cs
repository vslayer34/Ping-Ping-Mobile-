using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public abstract class Platform : MonoBehaviour
{
    // referance to the input manager
    [SerializeField] protected InputManager inputManager;

    [SerializeField, Tooltip("Reference to the game data")]
    protected SO_ManagerData _sessionData;

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
    /// Takes the input direction and moves the platform accordingly
    /// Apply lateral speed to the platforms
    /// </summary>
    /// <param name="inputDirection"></param>
    protected void Move(float inputDirection)
    {
        float movementDirection = inputDirection * Time.deltaTime * speed;
        float lateralSpeed = _sessionData.HorizontalSpeed * Time.deltaTime * -1.0f;
        Vector2 movementVector = new Vector3(lateralSpeed, movementDirection, 0.0f);

        // float movementDirection = inputDirection * Time.deltaTime * speed;
        // // float lateralSpeed = _sessionData.HorizontalSpeed * Time.deltaTime * -1.0f;
        // Vector2 movementVector = new Vector3(0.0f, movementDirection, 0.0f);

        // The -1 is to make for the movment limit in the negative y axis

        if (transform.position.y > _sessionData.MovementLimit)
        {
            transform.position = new Vector3(transform.position.x, _sessionData.MovementLimit, transform.position.z);
        }
        else if (transform.position.y < (_sessionData.MovementLimit * -1))
        {
            transform.position = new Vector3(transform.position.x, _sessionData.MovementLimit * -1, transform.position.z);
        }
        else
        {
            transform.Translate(movementVector);
        }
    }
}