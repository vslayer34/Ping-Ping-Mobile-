using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SO_ManagerData sessionData;

    [SerializeField, Tooltip("Movement limit for the platforms")]
    private float _platformLimit;

    private void Awake()
    {
        sessionData.MovementLimit = _platformLimit;
    }
}
