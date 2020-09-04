using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    float jumpForce = 4f;

    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * .6f, Color.green);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb2D.velocity = new Vector2(move, rb2D.velocity.y);
    }

    bool IsGrounded()
    {
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .6f, 1 << 8);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .6f, groundLayer.value);

        if (hit.collider != null)
            return true;

        return false;
    }
}
