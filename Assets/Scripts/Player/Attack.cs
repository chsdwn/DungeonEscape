using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool CanDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (CanDamage)
            {
                hit.Damage();
                CanDamage = false;
                Debug.Log("Hit");
                StartCoroutine(Wait500msUntilHitAgainCoroutine());
                CanDamage = true;
            }
        }
    }

    IEnumerator Wait500msUntilHitAgainCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
