using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField, Tooltip("Right spawn point")]
    private Transform _spawnPoint;


    [SerializeField, Tooltip("Left destruction point")]
    private Transform _destroyPoint;


    [SerializeField, Tooltip("Reference to the session data")]
    private SO_ManagerData _sessionData;

    // reference to the spawned platform
    private GameObject _newPlatform;

    // to determine when the platform is spawing
    private bool _isSpawning;


    /// <summary>
    /// List that contains pool of platforms
    /// </summary>
    private List<GameObject> _platforms;

    private void Start()
    {
        _platforms = new List<GameObject>();
        PopulatePlatformsPool();
    }

    private void Update()
    {
        if (!_isSpawning)
        {
            StartCoroutine(SpawnPoolEveryTime(_sessionData.TimeInterval));
        }
    }

    /// <summary>
    /// Create a new instances of the platform and store in the platforms for future use
    /// </summary>
    private void PopulatePlatformsPool()
    {
        GameObject spawnedPlatform;


        for (int i = 0; i < _sessionData.PoolSize; i++)
        {
            spawnedPlatform = Instantiate(_sessionData.WildPlatform, _spawnPoint.position, Quaternion.identity);
            
            spawnedPlatform.SetActive(false);

            _platforms.Add(spawnedPlatform);
        }
    }


    /// <summary>
    /// Fetch one of the deactivated platforms in the scene
    /// </summary>
    /// <returns>Wild platform gameobject</returns>
    private GameObject GetPlatform()
    {
        for (int i = 0; i < _sessionData.PoolSize; i++)
        {
            if (_platforms[i].activeInHierarchy == false)
            {
                _platforms[i].SetActive(true);
                return _platforms[i];
            }
        }

        return null;
    }




    private IEnumerator SpawnPoolEveryTime(float time)
    {
        _isSpawning = true;
        _newPlatform = GetPlatform();
        yield return new WaitForSeconds(time);
        _isSpawning = false;
    }
}
