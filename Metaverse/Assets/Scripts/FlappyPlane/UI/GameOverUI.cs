using Metaverse;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyPlane
{
    public class GameOverUI : BaseUI
    {
        public override UIState UiState => UIState.GameOver;

        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI bestScoreText;

        public Button restartButton;
        public Button exitButton;

        private void Awake()
        {
            if (restartButton == null || exitButton == null)
            {
                Debug.LogError("Some Button is null");
                return;
            }

            restartButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();


            restartButton.onClick.AddListener(OnClickRestart);
            exitButton.onClick.AddListener(OnClickExit);

        }

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }

        public void SetBestScore(int bestScore)
        {
            bestScoreText.text = bestScore.ToString();
        }

        public void OnClickRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnClickExit()
        {
            GlobalManager.instance.SceneChange(SceneNumber.Metaverse);
        }


    }
}

