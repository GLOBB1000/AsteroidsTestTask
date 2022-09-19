using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private PlayerMovementSetting playerMovement;
    public PlayerMovementSetting PlayerMovement => playerMovement;

    [SerializeField]
    private List<Enemy> enemies;

    public List<Enemy> Enemies => enemies;

    [System.Serializable]
    public struct PlayerStats
    {
        public float Health;
    }

    [System.Serializable]
    public struct PlayerMovementSetting
    {
        public float MaxInertion;
        public float RotationSpeed;
        public float InertionRaiseValue;
    }

    [System.Serializable]
    public struct Enemy
    {
        //Имя или же идентификатор врага
        public string Id;

        public float Health;
        public float AttackSpeed;

        public float Speed;
    }
}
