using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollistionEnter : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 activeColor = new Color32(1,1,1,1);
    [SerializeField] Color32 normalColor = new Color32(1,1,1,1);
    bool holdPackage;
    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }  
    void OnCollisionEnter2D(Collision2D other) 
    {
        //Debug.Log("Collision Enter");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Customer" && holdPackage)
        {
            Debug.Log("this is your order thank you");
            spriteRenderer.color = normalColor;
            holdPackage = false;
        }

        if(other.tag == "Package" && !holdPackage)
        {
            Debug.Log("Package collect");
            spriteRenderer.color = activeColor;
            holdPackage = true;
            Destroy(other.gameObject,destroyDelay);
        }
    }

}
