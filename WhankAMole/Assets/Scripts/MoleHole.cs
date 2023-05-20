using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleHole : MonoBehaviour
{
    public Transform MoleTransform;

    public float Speed = 3;
    bool isMoveUp = false;

    public bool Canhit = false;

    public SpriteRenderer MoleRenderer;
    public Sprite NormalMole;
    public Sprite HitMole;

    float counter = 0;
    float Delay;

    // Start is called before the first frame update
    void Start()
    {
        RandomDelay();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > Delay)
        {
            isMoveUp = true;
            counter = 0;
            RandomDelay();
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //MoleTransform.localPosition = new Vector3(0, 0, 0);
            //isMoveUp = true;
        //}
        if (isMoveUp == true)
        {
            MoveMole();
        }

        if (MoleTransform.localPosition.y > -0.03)
        {
            isMoveUp = false;
        }
    }

    void MoveMole()
    {
        Canhit = true;
        MoleTransform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    public void HitByHammer()
    {
        MoleRenderer.sprite = HitMole;

        Invoke("Reset", 0.5f);
    }

    public void Reset()
    {
        counter = 0;
        RandomDelay();

        Canhit = false;
        MoleRenderer.sprite = NormalMole;
        MoleTransform.localPosition = new Vector3(0, -2.58f, 0);
    }

    void RandomDelay()
    {
        Delay = Random.Range(2.0f, 4.0f);
    }
}