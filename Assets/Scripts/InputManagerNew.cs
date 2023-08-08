using UnityEngine;

public class InputManagerNew : MonoBehaviour
{
    private PlatformAction platformAction;

    /// <summary>
    /// reference to store the joystick direction
    /// </summary>
    private Vector2 _joyStickDirection;

    private void Awake()
    {
        platformAction = new PlatformAction();
    }

    private void Start()
    {
        platformAction.Platform.Enable();
    }


    private void Update()
    {
        _joyStickDirection = platformAction.Platform.Move.ReadValue<Vector2>();
        //Debug.Log(JoyStickDirection);
    }


    /// <summary>
    /// Get the normalized value of the joystick vector
    /// </summary>
    public Vector2 JoyStickDirection { get => _joyStickDirection.normalized; }
}
