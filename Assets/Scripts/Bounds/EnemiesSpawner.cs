using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Range = UnityEngine.SocialPlatforms.Range;

namespace Enemies
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField]
        private List<Enemy> enemies;

        public float spawnDistance = 12f;
        public float spawnRate = 1f;
        public int amountPerSpawn = 1;

        [Range(0f, 45f)]
        public float trajectoryVariance = 15f;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        }

        public void Spawn()
        {
            for (int i = 0; i < amountPerSpawn; i++)
            {
                Enemy enemy = Random.Range(0, 100) > 70 ? enemies[1] : enemies[0];

                Vector2 spawnDirection = Random.insideUnitCircle.normalized;
                Vector3 spawnPoint = spawnDirection * spawnDistance;

                spawnPoint += transform.position;

                float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

                Enemy asteroid = Instantiate(enemy, spawnPoint, rotation);

                Vector2 trajectory = rotation * -spawnDirection;
                asteroid.SetTrajectory(trajectory);
            }
        }
    }
}


