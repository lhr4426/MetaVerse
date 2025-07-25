using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyPlane
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;


        private int currentScore = 0;

        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }

        public static bool isFirstLoading = true;

        private string bestScoreKey = "BestScore";

        private void Awake()
        {
            instance = this;
            uiManager = FindObjectOfType<UIManager>();
        }

        private void Start()
        {
            if (!isFirstLoading)
            {
                StartGame();
            }
            else
            {
                isFirstLoading = false;
            }
        }

        public void StartGame()
        {
            uiManager.GameStart();
        }

        public void GameOver()
        {

            Debug.Log("Game Over!");
            int bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);
            if(currentScore > bestScore)
            {
                bestScore = currentScore;
                PlayerPrefs.SetInt(bestScoreKey, bestScore);
            }

            uiManager.SetGameOver(currentScore, bestScore);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void AddScore(int score)
        {
            currentScore += score;
            uiManager.UpdateScore(currentScore);
            // Debug.Log("Score : " + currentScore);
        }

    }
}

