using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private float dirX;
    private SpriteRenderer sp;
    private BoxCollider2D bc;

    public float movementSpeed = 7f;
    public float jumpStrength = 11f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && CanJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
        }

        AnimationUpdate();


    }

    private void AnimationUpdate()
    {

        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sp.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sp.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("movementState", (int)state);
    }

    private bool CanJump()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
