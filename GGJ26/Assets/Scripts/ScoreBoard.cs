using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image scoreBar;
    void Awake()
    {
        SetScore(0, 0, false);
    }

    public void SetScore(int score, int diff, bool bAnimate = false)
    {
        int actualScore = Math.Clamp(score, 0, 100);
        
        if (bAnimate)
        {
            // TODO
        }

        scoreText.text = "Sus Level: " + actualScore.ToString() + "%";
        scoreBar.fillAmount = actualScore / 100.0f;
    }
}
