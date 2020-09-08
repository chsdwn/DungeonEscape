using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnimator;
    Animator swordArcAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        swordArcAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        playerAnimator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool isJumping)
    {
        playerAnimator.SetBool("IsJumping", isJumping);
    }

    public void Attack()
    {
        playerAnimator.SetTrigger("Attack");
        swordArcAnimator.SetTrigger("Swing");
    }
}
