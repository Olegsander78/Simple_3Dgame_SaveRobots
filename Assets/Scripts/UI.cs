using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;


    public void SetScoreText(int score)
    {
        ScoreText.text = score.ToString();
    }
}
