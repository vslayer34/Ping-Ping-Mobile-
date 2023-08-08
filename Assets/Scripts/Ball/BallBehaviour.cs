using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float bounceModifier;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    /// <summary>
    /// Shoot the ball when the player hit space
    /// </summary>
    public void AddLaunchForce()
    {
        // vector direction for the force and force magnitude
        float forceDirectionX = 1.0f;
        float forceDirectionY = 1.7f;
        float launchForce = 10.0f;

        rb.bodyType = RigidbodyType2D.Dynamic;

        // add shooting force to the ball
        Vector2 forceVector = new Vector2(forceDirectionX, Random.Range(-forceDirectionY, forceDirectionY));
        rb.AddForce(forceVector.normalized * launchForce, ForceMode2D.Impulse);


        //// make the platform inactive
        //status = Status.INACTIVE;

        //// remove immunity after 1 second
        //StartCoroutine(RemoveImmunity());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Increase the ball velocity by 1% each collision
        rb.velocity *= 1.01f;
    }
}
