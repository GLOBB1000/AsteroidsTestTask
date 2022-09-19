using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorBehavior : Enemy
{
    [SerializeField]
    private GameObject smallMeteorPrefab;

    private Vector3 randomDirection;

    private void Start()
    {
        var randomX = Random.Range(-10, 10);
        var randomY = Random.Range(-10, 10);

        randomDirection = new Vector3(randomX, randomY);
        Initialize();
    }

    public override void Update()
    {
        transform.position += randomDirection * enemySettings.Speed * Time.deltaTime;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    protected override void OnDead()
    {
        gameObject.SetActive(false);
        for(int i = 0; i < 2; i++)
        {
            var smallMeteor = Instantiate(smallMeteorPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
