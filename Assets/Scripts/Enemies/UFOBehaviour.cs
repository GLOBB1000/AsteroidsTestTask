using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBehaviour : Enemy, IDestroyable
{
    private PlayerBehaviour playerBehaviour;

    private void Start()
    {
        Initialize();
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
    }

    public override void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerBehaviour.transform.position, enemySettings.Speed * Time.deltaTime);
    }

    protected override void OnDead()
    {
        base.OnDead();
        Destroy(gameObject);
    }
}
