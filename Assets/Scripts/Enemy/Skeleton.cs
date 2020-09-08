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

        if (Health <= 0)
            Destroy(transform.gameObject);
    }
}
