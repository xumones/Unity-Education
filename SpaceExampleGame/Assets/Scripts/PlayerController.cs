using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update

    int score = 0;

    public Text ScoreText;

    void Start()
    {
        Debug.Log("Hello World");

        Debug.Log("This object position is :" + transform.position);
        Debug.Log("This object rotation is :" + transform.rotation);
        Debug.Log("This object scale is :" + transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit " + collision);
        //score += 1;
        collision.gameObject.SetActive(false);

        if (collision.gameObject.tag == "Bomb")
        {
            gameObject.SetActive(false);
            ScoreText.text = "Gameover";
        }
        else
        {
            score += 1;
            ScoreText.text = "Score : " + score;
            collision.gameObject.SetActive(false);
        }
    }
}
