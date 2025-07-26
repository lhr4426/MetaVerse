using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeShooter
{
    public enum UIState
    {
        Home,
        Game,
        Pause,
        GameOver
    }
    public class UIManager : MonoBehaviour
    {
        private UIState currentState;

        private HomeUI homeUI;
        private GameUI gameUI;
        private PauseUI pauseUI;
        private GameOverUI gameOverUI;

        private void Awake()
        {
            homeUI = FindObjectOfType<HomeUI>();
            homeUI.Init(this);

            gameUI = FindObjectOfType<GameUI>();
            gameUI.Init(this);

            pauseUI = FindObjectOfType<PauseUI>();
            pauseUI.Init(this);

            gameOverUI = FindObjectOfType<GameOverUI>();
            gameOverUI.Init(this);

            ChangeUI(currentState);
        }

        void ChangeUI(UIState state)
        {
            homeUI.SetActive(state);
            gameUI.SetActive(state);
            pauseUI.SetActive(state);
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
            // gameOverUI.SetScore(score);
           // gameOverUI.SetBestScore(bestScore);
        }

        public void UpdateScore(int score)
        {
            // gameUI.SetScore(score);
        }

        public void PauseGame(bool isPause)
        {
            // TODO : Pause 구현하기
            if (isPause)
            {
                currentState = UIState.Pause;
                Time.timeScale = 0f;
            }
            else
            {
                currentState = UIState.Game;
                Time.timeScale = 1f;
            }
                
            ChangeUI(currentState);
        }
    }

}
