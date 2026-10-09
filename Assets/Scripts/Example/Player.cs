using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float JumpForce = 15f;

    public LayerMask GroundLayer;
    public float GroundCheckDistance = 0.5f;

    public SpriteRenderer SpriteRenderer;
    public Sprite DeadSprite;

    private bool _isGrounded = true;

    public GameManager GameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, GroundLayer);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && _isGrounded)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            SpriteRenderer.sprite = DeadSprite;
            GameManager.OnDeath();
        }
    }
}
