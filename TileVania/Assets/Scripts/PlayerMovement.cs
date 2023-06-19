using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedVelocity = 5f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform  gun;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;
    Rigidbody2D rigidbody2d;
    Animator animator;
    Vector2 moveInput;
    [SerializeField] Vector2 throwUp = new Vector2(30f,20f);
    float defaultGravityScale;
    bool isAlive = true;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        defaultGravityScale = rigidbody2d.gravityScale;
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        Instantiate(bullet,gun.position,transform.rotation);
    }

    void OnMove(InputValue Value)
    {
        if (!isAlive) { return; }
        moveInput = Value.Get<Vector2>();
    }

    void OnJump(InputValue Value)
    {
        if(!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || !isAlive) { return; }
        if(Value.isPressed)
        {
            rigidbody2d.velocity += new Vector2(0f,jumpForce);
        }
    }

    void ClimbLadder()
    {
        if (!isAlive) { return; }
        if(!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"))) 
        { 
            rigidbody2d.gravityScale = defaultGravityScale;
            animator.SetBool("isClimbing",false);
            return; 
        }
        bool playerHasClimb = Mathf.Abs(rigidbody2d.velocity.y) > Mathf.Epsilon;
        Vector2 climbVelocity = new Vector2(rigidbody2d.velocity.x, moveInput.y * climbSpeed);
        rigidbody2d.velocity = climbVelocity;
        rigidbody2d.gravityScale = 0;
        animator.SetBool("isClimbing",playerHasClimb);
    }

    void Run()
    {
        bool playerHasMove = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;

        Vector2 playerVelocity = new Vector2(moveInput.x * speedVelocity, rigidbody2d.velocity.y);
        rigidbody2d.velocity = playerVelocity;

        animator.SetBool("isRunning",playerHasMove);
    }
    void FlipSprite()
    {
        bool playerHasMove = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;
        if(playerHasMove)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rigidbody2d.velocity.x),1f);
        } 
    }

    void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazard")))
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            rigidbody2d.velocity = throwUp;
            bodyCollider.enabled = false;
            feetCollider.enabled = false;

        }
    }
}