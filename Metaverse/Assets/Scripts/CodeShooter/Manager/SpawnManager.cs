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

        [SerializeField] public Sprite[] npcSprites;
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
            if (NPCSprites.Length == 0)
                Debug.LogError("No Sprites");
        }

        private void Start()
        {
            XRange = rectTransform.sizeDelta.x / 2;
            YRange = rectTransform.sizeDelta.y / 2;
        }

        public void GameStart()
        {
            InvokeRepeating("SpawnEnemy", 0.2f, SpawnDelay);
        }

        public void Pause()
        {
            CancelInvoke();
        }

        public void SpawnEnemy()
        {
            int spriteNum = Random.Range(0, npcSprites.Length);
            Sprite sprite = npcSprites[spriteNum];
            Vector3 randomPos = new Vector3(
                Random.Range(-XRange, XRange), 
                Random.Range(-YRange, YRange)
                );
            GameObject go = Instantiate(NPCPrefab, randomPos, Quaternion.identity);
            Enemy enemy = go.GetComponent<Enemy>();
            enemy.Init(gameManager);
            Debug.Log($"Sprite Number : {spriteNum}");
            enemy.SetSprite(sprite);
        }
    }

}
