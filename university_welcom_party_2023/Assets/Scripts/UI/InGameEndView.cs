using System.Collections;
using System.Collections.Generic;
using naichilab;
using UnityEngine;
using UnityEngine.UI;

public class InGameEndView : MonoBehaviour
{
    [SerializeField] private Text scoreView;
    [SerializeField] private Text livesView;
    [SerializeField] private Text comboView;
    [SerializeField] private Text totalScoreView;

    public void ViewScore(int scorePoint)
    {
        scoreView.text = "SCORE : " + scorePoint;
    }

    public void ViewLives(int lives)
    {
        livesView.text = "LIVES : " + lives;
    }

    public void ViewMaxCombo(int maxComboAmount)
    {
        comboView.text = "MAX COMBO : " + maxComboAmount;
    }

    public void ViewTotalScore(int totalScore)
    {
        totalScoreView.text = totalScore.ToString();
    }
}
