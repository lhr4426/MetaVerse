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

        SpawnManager spawnManager;
        public SpawnManager SpawnManager { get { return spawnManager; } }



        private float timeLimit; // 1분동안 진행
        public float TimeLimit { get => timeLimit; set => timeLimit = value; }
        
        private bool isPlaying = false;
        private bool isPaused = false;

        


        private void Awake()
        {
            instance = this;
            bestScoreKey = "ShooterBestScore";
            uiManager = FindObjectOfType<UIManager>();
            uiManager.Init(this);
            spawnManager = FindObjectOfType<SpawnManager>();
        }

        private void Start()
        {
            player.SetActive(false);
        }

        private void Update()
        {
            if(isPlaying)
            {
                timeLimit -= Time.deltaTime;
                uiManager.SetTime(timeLimit);
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
            spawnManager.GameStart();
            timeLimit = maxTime;
            isPlaying = true;
            isPaused = false;
            player.SetActive(true);
        }

        public override void GameOver()
        {
            Debug.Log("Game Over!");
            spawnManager.Pause();
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
            foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemy);
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
                // player는 일시정지되었을 때 보이지 않아야 함
                // isPause == true 일 때 player 는 보이지 않아야 하기 때문에
                // 우선 isPaused로 하고 이후에 반대로 변경
                Player.SetActive(isPaused);
                isPaused = !isPaused;
                if (isPaused) spawnManager.Pause();
                else spawnManager.GameStart();
                uiManager.PauseGame();
            }
        }

    }
}

