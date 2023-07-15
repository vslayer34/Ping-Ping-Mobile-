using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    private Camera mainCamera;
    public static Dictionary<int, Vector3> touchsDict;

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
            // get the finger index and the coresponting position in the world
            var touch = activeTouches[i].screenPosition;

            Vector3 screenPosition = new Vector3(touch.x, touch.y, 0.0f);
            Vector3 worldPosition =  mainCamera.ScreenToWorldPoint(screenPosition);
            Debug.Log($"{activeTouches[i].finger.index} : {worldPosition}");
            
            // and added to the touch dictionary
            if (!touchsDict.TryAdd(i, worldPosition))
            {
                touchsDict[i] = worldPosition;
            }
        }

        touchsDict.TryGetValue(0, out Vector3 value0);
        Debug.Log(value0);
        touchsDict.TryGetValue(1, out Vector3 value1);
        Debug.Log(value1);
    }


    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
}
