using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayVault = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool playOnce = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (playOnce)
            {
            if (other.tag == "Ground")
            {
                playOnce = false;
                GetComponent<PlayerControl>().DisableControl();
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                Invoke("DetectCrash",delayVault);
            }
        }
    }

    void DetectCrash()
    {
        SceneManager.LoadScene(0);
    }
}
