using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpStrength = 5;
    public float groundedCheckDistance = 2f;

    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundedCheckDistance, LayerMask.GetMask("Ground"));

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isDead)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            }
        }
    }

    private void onCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Obstacle.moveSpeed = 0f;
            ObstacleSpawner.doesSpawning = false;
            isDead = true;
        }
    }
}
