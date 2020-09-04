using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb2D.AddForce(Vector2.up * jumpForce);
                Debug.Log("jump");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb2D.velocity = new Vector2(move, 0);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, .6f, LayerMask.GetMask("Floor"));

        if (hit.collider != null)
            return true;

        return false;
    }
}
