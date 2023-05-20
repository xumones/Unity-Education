using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer Renderer;
    Rigidbody rigidBody;
    [SerializeField]float time_Past = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        Renderer.enabled = false;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > time_Past)
        {
            Renderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }
}
