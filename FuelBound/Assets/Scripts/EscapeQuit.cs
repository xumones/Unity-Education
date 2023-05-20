using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeQuit : MonoBehaviour
{
    void Update()
    {
        ExitCheck();
    }

    public void ExitCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape working");
            Application.Quit();
        }
    }
}
