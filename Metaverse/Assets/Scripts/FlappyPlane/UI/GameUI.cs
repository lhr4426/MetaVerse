using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FlappyPlane
{
    public class GameUI : BaseUI
    {
        public override UIState UiState => UIState.Game;

        public TextMeshProUGUI scoreText;


        public void SetScore(int score)
        {
            // Debug.Log($"GameUI Score Setting : {score}");
            scoreText.text = score.ToString();
        }

    }

}
