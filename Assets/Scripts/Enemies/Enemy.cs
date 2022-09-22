using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IEnemy, IDestroyable
{
    [SerializeField]
    private GameSettings settings;

    [SerializeField]
    private string id;

    public GameSettings.Enemy enemySettings { get; protected set; }

    protected float health;

    public bool isSpawnedRecentrly { get; set; }

    public GameSettings Settings { get; set; }
    public string Id { get; set; }

    protected float destroyTimer;

    protected Vector3 trajectory;

    public static event Action<float> OnEnemyDead;

    public virtual void Initialize()
    {
        enemySettings = settings.Enemies.Find(x => x.Id.Equals(id));

        health = enemySettings.Health;
        Debug.Log(enemySettings.Id);

        isSpawnedRecentrly = true;
        
    }

    public void SetTrajectory(Vector2 direction)
    {
        trajectory = direction;
    }

    protected virtual void OnDead()
    {
        OnEnemyDead?.Invoke(enemySettings.Points);
    }

    public abstract void Update();

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        var col = collision.collider;
        var projectile = col.GetComponent<Projectile>();

        if (projectile == null)
            return;

        OnDead();
    }
}
