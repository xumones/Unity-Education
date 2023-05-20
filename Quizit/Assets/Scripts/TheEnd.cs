using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TheEnd : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finishScoreText;
    ScoreKeeper scoreKeeper;
    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScene()
    {
        finishScoreText.text = "You reach the end of our question Congratulation!!\n" + 
                               "Your score = " + scoreKeeper.CalculateScore() + "%";
    }
}
