using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public abstract class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        protected int currentScore = 0;
        protected int bestScore;

        public static bool isFirstLoading = true;

        protected string bestScoreKey;

        

        private void Awake()
        {
            instance = this;
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

        public abstract void StartGame();

        public abstract void GameOver();

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public virtual void AddScore(int score)
        {
            currentScore += score;
        }

    }
}

