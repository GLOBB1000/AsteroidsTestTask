using Saves;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreGetter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScore;

    private void Awake()
    {
        highScore.text = $"Highscore: {SavingSystem.GetScore()}";
    }
}
