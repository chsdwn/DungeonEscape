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
    SpriteRenderer spriteRenderer;
    Transform swordArc;
    float move;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        swordArc = transform.GetChild(1);
    }

    void Update()
    {
        Jump();
        Attack();

        playerAnimation.Jump(!IsGrounded());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded())
            playerAnimation.Attack();
    }

    void Move()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);

        playerAnimation.Move(move);

        Flip();
    }

    void Flip()
    {
        SpriteRenderer sr = swordArc.GetComponent<SpriteRenderer>();
        Vector3 pos = swordArc.transform.position;

        if (move > 0)
        {
            spriteRenderer.flipX = false;

            sr.flipX = false;
            sr.flipY = false;

            swordArc.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true;

            sr.flipX = true;
            sr.flipY = true;

            swordArc.transform.position = new Vector3(-pos.x, pos.y, pos.z);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
                playerAnimation.Jump(true);
            }
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
