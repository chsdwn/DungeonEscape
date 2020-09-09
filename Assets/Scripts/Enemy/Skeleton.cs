using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

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
    }

    protected override void Movement()
    {
        base.Movement();

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 2f)
        {
            Debug.Log($"distance: {distance}");
            IsHit = false;
            anim.SetBool("InCombat", false);
        }
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
}
