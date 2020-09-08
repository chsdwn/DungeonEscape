using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    Animator anim;
    SpriteRenderer spriteRenderer;
    Vector3 target;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (IsAnimationPlaying("Idle"))
            return;

        Movement();
    }

    void Movement()
    {
        if (Mathf.Approximately(transform.position.x, pointA.position.x))
        {
            target = pointB.position;
            Flip(false);
        }
        else if (Mathf.Approximately(transform.position.x, pointB.position.x))
        {
            target = pointA.position;
            Flip(true);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void Flip(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }

    bool IsAnimationPlaying(string name)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return true;

        return false;
    }
}
