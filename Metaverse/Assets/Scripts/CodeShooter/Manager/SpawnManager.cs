using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeShooter
{
    public class SpawnManager : MonoBehaviour
    {
        [Header("Game Settings")]
        [SerializeField] private float spawnDelay;
        public float SpawnDelay { get { return spawnDelay; } }

        [SerializeField] private Sprite[] npcSprites;
        public Sprite[] NPCSprites { get { return npcSprites; } }

        [SerializeField] private GameObject npcPrefab;
        public GameObject NPCPrefab { get { return npcPrefab; } }

        GameManager gameManager;
        RectTransform rectTransform;

        float XRange;
        float YRange;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            XRange = rectTransform.sizeDelta.x / 2;
            YRange = rectTransform.sizeDelta.y / 2;
        }

        public void GameStart()
        {

        }

        public void SpawnEnemy()
        {
            int spriteNum = Random.Range(0, npcSprites.Length);
            Vector3 randomPos = new Vector3(
                Random.Range(-XRange, XRange), 
                Random.Range(-YRange, YRange)
                );

        }


    }

}
