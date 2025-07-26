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

        [SerializeField] private Enemy[] npcPrefabs;
        public Enemy[] NPCPrefabs { get { return npcPrefabs; } }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
