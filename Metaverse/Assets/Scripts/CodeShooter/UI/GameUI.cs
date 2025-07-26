using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CodeShooter
{
    public class GameUI : BaseUI
    {
        public override UIState UiState => UIState.Game;

        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI scoreText;
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        public void SetTime()
        {
            float timeLimit = gameManager.TimeLimit;
            timeText.text = timeLimit.ToString("N2") + "√ ";
        }

        public void SetScore(int score)
        {
            scoreText.text = score.ToString() + "¡°";
        }
    }

}
