using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScoreAndLivesView : MonoBehaviour
{
    [SerializeField] private Text scoreView;
    [SerializeField] private Text livesView;
    [SerializeField] private Text comboView;

    public void ViewScore(int score)
    {
        scoreView.text = "SCORE : " + score;
    }

    public void ViewLives(int lives)
    {
        livesView.text = "LIVES ： " + lives;
    }

    public void ViewCombo(int comboAmount)
    {
        comboView.text = "COMBO : " + comboAmount;
    }
}
