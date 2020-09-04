using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float velocity = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);
    }
}
