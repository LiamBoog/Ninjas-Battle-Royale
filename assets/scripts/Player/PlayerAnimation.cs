using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D body;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(body.velocity.x));
        animator.SetBool("rising", body.velocity.y > 0);
        animator.SetBool("falling", body.velocity.y < -1.5);
    }
}
