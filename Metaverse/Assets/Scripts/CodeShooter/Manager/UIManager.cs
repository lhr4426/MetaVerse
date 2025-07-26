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
        public UIState CurrentState { get { return currentState; } }

        private HomeUI homeUI;
        private GameUI gameUI;
        private PauseUI pauseUI;
        private GameOverUI gameOverUI;

        private GameManager gameManager;

        public void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        private void Awake()
        {
            homeUI = GetComponentInChildren<HomeUI>(true);
            homeUI.Init(this);

            gameUI = GetComponentInChildren<GameUI>(true);
            gameUI.Init(this);

            pauseUI = GetComponentInChildren<PauseUI>(true);
            pauseUI.Init(this);

            gameOverUI = GetComponentInChildren<GameOverUI>(true);
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

        public void StartButton()
        {
            gameManager.StartGame();
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

        public void PauseGame()
        {
            if (CurrentState == UIState.Game)
            {
                currentState = UIState.Pause;
                Time.timeScale = 0f;
            }
            else if (CurrentState == UIState.Pause)
            {
                currentState = UIState.Game;
                Time.timeScale = 1f;
            }
            else return;
            ChangeUI(currentState);
        }

        public void SetTime(float time)
        {
            if (gameUI.enabled)
                gameUI.SetTime(time);
        }
    }

}
