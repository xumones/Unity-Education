using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]float bulletSpeed = 3f;
    Rigidbody2D rigidbody2d;
    PlayerMovement player;
    float xBulletSpeed;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xBulletSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        rigidbody2d.velocity = new Vector2(xBulletSpeed , 0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }
}
