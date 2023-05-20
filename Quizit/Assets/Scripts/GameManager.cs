using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    TheEnd theEnd;
    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        theEnd = FindObjectOfType<TheEnd>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        theEnd.gameObject.SetActive(false);
    }

    void Update()
    {
        if(quiz.isComplete == true)
        {
            quiz.gameObject.SetActive(false);
            theEnd.gameObject.SetActive(true);
            theEnd.ShowFinalScene();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
