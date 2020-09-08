using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointLeft, pointRight;

    protected Animator anim;
    protected SpriteRenderer spriteRenderer;
    protected Vector3 target;

    protected bool IsHit = false;

    void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        if (IsAnimationPlaying("Idle"))
            return;

        if (!IsHit)
            Movement();
    }

    protected virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected void Movement()
    {
        if (Mathf.Approximately(transform.position.x, pointLeft.position.x))
        {
            target = pointRight.position;
            spriteRenderer.flipX = false;
            anim.SetTrigger("Idle");
        }
        else if (Mathf.Approximately(transform.position.x, pointRight.position.x))
        {
            target = pointLeft.position;
            spriteRenderer.flipX = true;
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    protected bool IsAnimationPlaying(string name)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(name))
            return true;

        return false;
    }
}
