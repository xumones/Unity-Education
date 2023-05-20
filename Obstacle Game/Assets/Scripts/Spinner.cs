using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float angleX = 0f;
    [SerializeField] float angleY = 0f;
    [SerializeField] float angleZ = 0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(angleX,angleY,angleZ);
    }
}
