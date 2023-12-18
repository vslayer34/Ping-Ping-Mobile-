using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SO_ManagerData sessionData;

    private float _platformLimit;

    private void Awake()
    {
        sessionData.movementLimit = _platformLimit;
    }
}
