using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
        playerAnimator.SetFloat("Move", Mathf.Abs(move));
    }
}
