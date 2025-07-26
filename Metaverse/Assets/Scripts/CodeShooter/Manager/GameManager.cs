using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeShooter
{

    public class GameManager : Global.GameManager
    {
        [Header("Game Setting")]
        [SerializeField] private float maxTime;

        [Header("Player")]
        [SerializeField] private GameObject player;
        public GameObject Player { get { return player; } }

        UIManager uiManager;
        public UIManager UIManager { get { return uiManager; } }

        



        private float timeLimit; // 1분동안 진행
        public float TimeLimit { get => timeLimit; set => timeLimit = value; }
        
        private bool isPlaying = false;
        private bool isPaused = false;

        


        private void Awake()
        {
            instance = this;
            bestScoreKey = "ShooterBestScore";
            uiManager = FindObjectOfType<UIManager>();
        }

        private void Start()
        {
            player.SetActive(false);
        }

        private void Update()
        {
            // Debug.Log("Tick");
            if(isPlaying)
            {
                Debug.Log("Tock");
                timeLimit -= Time.deltaTime;
                uiManager.SetTime();
                if(TimeLimit <= 0f)
                {
                    isPlaying = false;
                    GameOver();
                }
            }
        }

        public override void StartGame()
        {
            Debug.Log("Game Start");
            uiManager.GameStart();
            timeLimit = maxTime;
            isPlaying = true;
            isPaused = false;
            player.SetActive(true);
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
            player.SetActive(false);
            foreach(var bullet in GameObject.FindGameObjectsWithTag("Bullet"))
            {
                Destroy(bullet);
            }
            uiManager.SetGameOver(currentScore, bestScore);
            
        }


        public override void AddScore(int score)
        {
            base.AddScore(score);
            uiManager.UpdateScore(currentScore);
        }

        void OnPause(InputValue inputValue)
        {
            if (inputValue.isPressed)
            {
                Player.SetActive(isPaused);
                isPaused = !isPaused;
                uiManager.PauseGame();
            }
        }

    }
}

