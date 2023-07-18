using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    private Camera mainCamera;
    public static Dictionary<int, Vector3> touchsDict;

    /// <summary>
    /// Get the world position of the active touch
    /// </summary>
    public Vector3 ActiveTouchPosition { get; private set; }
    /// <summary>
    /// Get if the player is touching the screen or not
    /// </summary>
    public bool IsActiveTouch { get; private set; }
    public bool IsFingerLifted { get; private set; }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void Start()
    {
        touchsDict = new Dictionary<int, Vector3>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        var activeTouches = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;
        for (int i = 0; i < activeTouches.Count; i++)
        {
            UnityEngine.InputSystem.TouchPhase activePhase;
            
            // get the finger index and the coresponting position in the world
            var touch = activeTouches[i].screenPosition;
            activePhase = activeTouches[i].phase;

            // check if the finger is lifted or still touching the screen
            IsFingerLifted = (activePhase == UnityEngine.InputSystem.TouchPhase.Ended) ? true : false;


            Vector3 screenPosition = new Vector3(touch.x, touch.y, 0.0f);
            Vector3 worldPosition =  mainCamera.ScreenToWorldPoint(screenPosition);
            worldPosition.z = 0.0f;
            ActiveTouchPosition = worldPosition;

            //Debug.Log($"{activeTouches[i].finger.index} : {worldPosition}");

            // and added to the touch dictionary
            /*
            if (!touchsDict.TryAdd(i, worldPosition))
            {
                touchsDict[i] = worldPosition;
            }
            */
        }

            IsActiveTouch = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches.Count == 0 ? false : true;
        // set a boolean whether the user is touching the screen or not
    }


    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
}
