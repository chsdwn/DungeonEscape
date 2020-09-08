using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
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
            anim.SetTrigger("Idle");
            spriteRenderer.flipX = false;
        }
        else if (Mathf.Approximately(transform.position.x, pointB.position.x))
        {
            target = pointA.position;
            anim.SetTrigger("Idle");
            spriteRenderer.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    bool IsAnimationPlaying(string name)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(name))
            return true;

        return false;
    }
}
