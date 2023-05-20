using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustValue = 1000f;
    [SerializeField] float rotateValue = 100f;
    [SerializeField] AudioClip SFX_fly; 

    [SerializeField] ParticleSystem PTC_thrush; 
    [SerializeField] ParticleSystem PTC_left; 
    [SerializeField] ParticleSystem PTC_right;

    Rigidbody rgbody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessFly();
        ProcessRotate();
    }

    void ProcessFly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PTC_thrush.Play(); // effect will appear because loop in particle is off
            rgbody.AddRelativeForce(Vector3.up * thrustValue * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(SFX_fly);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PTC_right.Play(); // effect will appear because loop in particle is off
            ApplyRotation(rotateValue);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PTC_left.Play(); // effect will appear because loop in particle is off
            ApplyRotation(-rotateValue);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rgbody.freezeRotation = true; //freezing for stop unity physic
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rgbody.freezeRotation = false; //unfreezing for start unity physic over agian
    }
}
