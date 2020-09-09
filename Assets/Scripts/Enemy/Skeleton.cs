using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    Vector3 direction;

    protected override void Init()
    {
        base.Init();

        Health = health;
    }

    protected override void Update()
    {
        if (IsAnimationPlaying("Idle") && !anim.GetBool("InCombat"))
            return;

        Movement();
        ChangeDirectionBeforeAttack();
    }

    protected override void Movement()
    {
        base.Movement();

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 2f)
        {
            IsHit = false;
            anim.SetBool("InCombat", false);
        }

        direction = (player.transform.localPosition - transform.localPosition).normalized;
    }

    public void Damage()
    {
        Health--;
        IsHit = true;

        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);

        if (Health <= 0)
            Destroy(transform.gameObject);
    }

    void ChangeDirectionBeforeAttack()
    {
        if (direction.x > 0 && anim.GetBool("InCombat"))
            spriteRenderer.flipX = false;
        else if (direction.x < 0 && anim.GetBool("InCombat"))
            spriteRenderer.flipX = true;
    }
}
