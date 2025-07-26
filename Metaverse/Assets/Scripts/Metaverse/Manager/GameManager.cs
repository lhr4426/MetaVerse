using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Metaverse
{
    public class GameManager : MonoBehaviour
    {

        private static GameManager instance;
        public GameManager Instance {  get { return instance; } }

        [SerializeField] private GameObject player;
        public GameObject Player { get { return player; } }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }

            if(player == null)
            {
                Debug.LogError("Player is null");
            }
        }

        private void OnEnable()
        {
            Time.timeScale = 1.0f;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (GlobalManager.instance.lastPosition != Vector2.zero)
            {

                player.transform.position = GlobalManager.instance.lastPosition;
            }
            else
            {
                player.transform.position = Vector2.zero;
            }
        }
    }
}

