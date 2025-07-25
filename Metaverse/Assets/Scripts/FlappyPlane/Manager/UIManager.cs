using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FlappyPlane
{

    public enum UIState
    {
        Home,
        Game,
        GameOver
    }

    public class UIManager : MonoBehaviour
    {
        private HomeUI homeUI;
        private GameUI gameUI;
        private GameOverUI gameOverUI;

        private UIState currentState;

        private void Awake()
        {
            homeUI = GetComponentInChildren<HomeUI>(true);
            homeUI.Init(this);

            gameUI = GetComponentInChildren<GameUI>(true);
            gameUI.Init(this);

            gameOverUI = GetComponentInChildren<GameOverUI>(true);
            gameOverUI.Init(this);

            ChangeUI(currentState);
        }
        

        void ChangeUI(UIState state)
        {
            homeUI.SetActive(state);
            gameUI.SetActive(state);
            gameOverUI.SetActive(state);
        }

        public void GameStart()
        {
            currentState = UIState.Game;
            ChangeUI(currentState);

            Time.timeScale = 1f;
            Debug.Log("게임 시작");
        }

        public void SetPlayGame()
        {
            currentState = UIState.Game;
            Time.timeScale = 1f;
            ChangeUI(currentState);
        }

        public void SetGameOver(int score, int bestScore)
        {
            currentState = UIState.GameOver;
            Time.timeScale = 0f;
            ChangeUI(currentState);
            gameOverUI.SetScore(score);
            gameOverUI.SetBestScore(bestScore);
        }

        public void UpdateScore(int score)
        {
            gameUI.SetScore(score);
        }
        
    }
}

