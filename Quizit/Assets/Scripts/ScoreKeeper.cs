using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int questionsSeen = 0;
    int correctScore = 0;

    public int GetCorrectScore()
    {
        return correctScore;
    }

    public void IncrementCorrectScore()
    {
        correctScore++;
    }

    public int GetQuestionsSeen()
    {
        return questionsSeen;
    }

    public void IncrementQuestionsSeen()
    {
        questionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctScore / (float)questionsSeen * 100);
    }
}
