using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmallMeteorBehaviour : Enemy
{
    private Vector3 randomDirection;

    private void Start()
    {
        Initialize();

        var randomX = Random.Range(-10, 10);
        var randomY = Random.Range(-10, 10);
        randomDirection = new Vector3(randomX, randomY);

        destroyTimer = 1;
    }

    public override void Update()
    {
        transform.position += randomDirection * enemySettings.Speed * Time.deltaTime;

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
        Destroy(gameObject);
    }
}
