using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    Vector3 target;

    public override void Attack() { }
    public override void Update()
    {

        if (Mathf.Approximately(transform.position.x, pointA.position.x))
        {
            target = pointB.position;
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else if (Mathf.Approximately(transform.position.x, pointB.position.x))
        {
            target = pointA.position;
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
