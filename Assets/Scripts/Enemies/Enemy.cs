using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IEnemy, IDestroyable
{
    [SerializeField]
    private GameSettings settings;

    [SerializeField]
    private string id;

    protected GameSettings.Enemy enemySettings;
    private Collider2D enemyCollider;

    protected float health;

    public GameSettings Settings { get; set; }
    public string Id { get; set; }

    public virtual void Initialize()
    {
        enemySettings = settings.Enemies.Find(x => x.Id.Equals(id));
        health = enemySettings.Health;
        Debug.Log(enemySettings.Id);
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        Debug.Log("Ouch " + health);

        if (health <= 0)
        {
            OnDead();
        }
    }

    protected abstract void OnDead();

    public abstract void Update();

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        var col = collision.collider;
        var projectile = col.GetComponent<Projectile>();

        if (projectile == null)
            return;

        GetDamage(projectile.Damage);

        col.gameObject.SetActive(false);
    }
}
