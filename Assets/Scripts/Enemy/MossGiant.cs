using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    Animator animator;
    Vector3 target;

    public override void Attack() { }
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
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.flipX = flipX;
    }

    bool IsAnimationPlaying(string name)
    {
        Animator anim = GetComponentInChildren<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            return true;

        return false;
    }
}
