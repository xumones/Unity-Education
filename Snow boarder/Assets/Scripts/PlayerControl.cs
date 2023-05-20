using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float torqueVault = 1f;
    [SerializeField] float baseSpeed = 23f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float reduceSpeed = 15f;
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rigidBody;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            BoostPlayer();
        }
    }

    public void DisableControl()
    {
        canMove = false;
    }

    void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = reduceSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddTorque(torqueVault);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddTorque(-torqueVault);
        }
    }
}
