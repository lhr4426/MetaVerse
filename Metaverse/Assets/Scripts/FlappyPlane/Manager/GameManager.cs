using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyPlane
{
    public class GameManager : Global.GameManager
    {
        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }


        private void Awake()
        {
            instance = this;
            bestScoreKey = "FlappyBestScore";
            uiManager = FindObjectOfType<UIManager>();
        }

        public override void StartGame()
        {
            uiManager.GameStart();
        }

        public override void GameOver()
        {
            Debug.Log("Game Over!");
            int bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                PlayerPrefs.SetInt(bestScoreKey, bestScore);
            }
            Debug.Log($"key : {bestScoreKey} | score : {bestScore}");
            uiManager.SetGameOver(currentScore, bestScore);
        }


        public override void AddScore(int score)
        {
            base.AddScore(score);
            uiManager.UpdateScore(currentScore);
        }

    }
}

