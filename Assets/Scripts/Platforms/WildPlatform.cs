using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPlatform : Platform
{
    private void Awake()
    {
        platformAction = new PlatformAction();
        instanceNumber++;
    }

    private void Start()
    {
        //_rb = GetComponent<Rigidbody2D>();
        platformAction.Enable();
        //Debug.Log(instanceNumber.ToString());
    }

    private void Update()
    {
        //Debug.Log(JoystickDirectionY);
        //touchPosition = inputManager.ActiveTouchPosition;
        //Debug.Log($"{gameObject.name}: current moving Vector: {JoyStickDirectionNormalized}");
        Move(JoystickDirectionY);
    }


    private void FixedUpdate()
    {
        //Move(JoystickDirectionY);
    }


    private void OnDisable()
    {
        platformAction?.Disable();
    }
}
