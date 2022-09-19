using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;
using Range = UnityEngine.SocialPlatforms.Range;

public class EnemiesSpawner : MonoBehaviour
{
    float time = 0.0f;
    float minimumY;
    float maximumY;
    float minimumX;
    float maximumX;

    [SerializeField]
    private Vector3 screenCenter;

    [SerializeField]
    private float maxRange = 10f;

    [SerializeField]
    private float minRange = 5f;

    [SerializeField]
    private float spawnInterval = 3;

    [SerializeField]
    private GameObject meteorPrefab;

    private void Start()
    {
        screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        this.minimumY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).y;
        this.maximumY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -Camera.main.transform.position.z)).y;
        this.minimumX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).x;
        this.maximumX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -Camera.main.transform.position.z)).x;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnInterval)
        {
            time = time - spawnInterval;

            InstantiateRandomAsteroid();
        }
    }

    void InstantiateRandomAsteroid()
    {
        bool targetPending = true;

        float spawnX = 0;
        float spawnY = 0;

        while (targetPending)
        {
            spawnX = Random.Range(minimumX - maxRange, maximumX + maxRange);
            spawnY = Random.Range(minimumY - maxRange, maximumY + maxRange);

            // Avoiding spawning 2 asteroids ont op of each other
            Collider[] colliders = Physics.OverlapBox(new Vector3(spawnX, spawnY, 0), new Vector3(1, 1, 1));
            targetPending = colliders.Length > 0;
        }

        GameObject asteroidObject = Instantiate(meteorPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(0, 0, 0));

        asteroidObject.transform.LookAt(screenCenter);
    }
}
