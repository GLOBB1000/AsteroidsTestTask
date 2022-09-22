using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager: MonoBehaviour
{ 
    public float Score { get; private set; }

    private void Start()
    {
        Enemy.OnEnemyDead += Enemy_OnEnemyDead;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDead -= Enemy_OnEnemyDead;
    }

    private void Enemy_OnEnemyDead(float points)
    {
        Score += points;
    }
}
