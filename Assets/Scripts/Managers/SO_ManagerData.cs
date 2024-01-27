using UnityEngine;

[CreateAssetMenu(fileName = "session data", menuName = "Mangers/Game Tracker")]
public class SO_ManagerData : ScriptableObject
{
    [field: Header("Pool Settings")]
    [field: SerializeField, Tooltip("Reference to the platform prefab")]

    public GameObject WildPlatform {  get; set; }

    
    [field: SerializeField, Tooltip("Number of platforms in the pool")]
    public int PoolSize { get; set; }


    
    [field: Space(5), Header("Level settings")]
    [field: SerializeField, Tooltip("The boundries of the level")]
    public float MovementLimit {  get; set; }

    [field: Header("Setting for spawning platform")]
    
    [field: SerializeField, Tooltip("The speed the platforms flow through the screen")]
    public float HorizontalSpeed { get; private set; }


    [field: SerializeField, Tooltip("Time interval for spawning new platform")]
    public float TimeInterval { get; private set; }
}
