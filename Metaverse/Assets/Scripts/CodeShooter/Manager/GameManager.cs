using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeShooter
{
    public class GameManager : Global.GameManager
    {

        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }

        private bool isPause = false;

        private void Awake()
        {
            instance = this;
            bestScoreKey = "ShooterBestScore";
            uiManager = FindObjectOfType<UIManager>();
        }

        public override void StartGame()
        {
            uiManager.GameStart();
        }

        public override void GameOver()
        {
            base.GameOver();
            uiManager.SetGameOver(currentScore, bestScore);
        }


        public override void AddScore(int score)
        {
            base.AddScore(score);
            uiManager.UpdateScore(currentScore);
        }

        public void Pause()
        {
            isPause = !isPause;
            uiManager.PauseGame(isPause);
        }

        
    }
}

