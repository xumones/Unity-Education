using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D rigidbody2d;
    void Start()
    {
        rigidbody2d =GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody2d.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        moveSpeed = -moveSpeed;
        FlipEnemySprite();
    }

    void FlipEnemySprite()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(rigidbody2d.velocity.x)),1f);
    }
}
