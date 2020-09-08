using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    protected static string IDLE_ANIMATION = "Idle";

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
        if (IsAnimationPlaying(IDLE_ANIMATION))
            return;

        Movement();
    }

    void Movement()
    {
        if (Mathf.Approximately(transform.position.x, pointA.position.x))
        {
            target = pointB.position;
            Flip(false);
            anim.SetTrigger(IDLE_ANIMATION);
        }
        else if (Mathf.Approximately(transform.position.x, pointB.position.x))
        {
            target = pointA.position;
            Flip(true);
            anim.SetTrigger(IDLE_ANIMATION);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void Flip(bool flipX)
    {
        spriteRenderer.flipX = flipX;
    }

    bool IsAnimationPlaying(string name)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(name))
            return true;

        return false;
    }
}
