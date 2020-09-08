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
