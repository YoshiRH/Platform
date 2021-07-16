using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private float dirX;
    private SpriteRenderer sp;

    public float movementSpeed = 7f;
    public float jumpStrength = 11f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }

        AnimationUpdate();


    }

    private void AnimationUpdate()
    {
        if (dirX > 0f)
        {
            animator.SetBool("Running", true);
            sp.flipX = false;
        }
        else if (dirX < 0f)
        {
            animator.SetBool("Running", true);
            sp.flipX = true;
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
