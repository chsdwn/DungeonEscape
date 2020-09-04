using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    float jumpForce = 4f;
    [SerializeField]
    float speed = 4f;

    Rigidbody2D rb2D;
    PlayerAnimation playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

        playerAnimation.Move(move);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    bool IsGrounded()
    {
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .6f, 1 << 8);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .65f, groundLayer.value);

        if (hit.collider != null)
            return true;

        return false;
    }
}
