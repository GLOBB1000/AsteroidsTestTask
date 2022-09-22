using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorBehavior : Enemy
{
    [SerializeField]
    private GameObject smallMeteorPrefab;

    private Vector3 randomDirection;

    private void Start()
    {
        Initialize();

        var randomX = Random.Range(-10, 10);
        var randomY = Random.Range(-10, 10);
        randomDirection = new Vector3(randomX, randomY);

        destroyTimer = 2;
    }

    public override void Update()
    {
        transform.position += trajectory * enemySettings.Speed * Time.deltaTime;

        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0)
            isSpawnedRecentrly = false;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    protected override void OnDead()
    {
        base.OnDead();
        gameObject.SetActive(false);
        for(int i = 0; i < 2; i++)
        {
            var smallMeteor = Instantiate(smallMeteorPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
