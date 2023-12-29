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

    private void OnEnable()
    {
        ActivatePlatformSections();
    }


    private void OnDisable()
    {
        platformAction?.Disable();
    }


    /// <summary>
    /// Activate all the indiviual section of the platform
    /// when enabled after spawning
    /// </summary>
    private void ActivatePlatformSections()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
          
    }
}
