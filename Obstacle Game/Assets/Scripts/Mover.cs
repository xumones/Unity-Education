using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        print_Instruction();
    }

    // Update is called once per frame
    void Update()
    {
        move_Player();
    }
    void print_Instruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD");
        Debug.Log("Beware don't hit the walls!");
    }
    
    void move_Player()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue,0,yValue);
    }
}
