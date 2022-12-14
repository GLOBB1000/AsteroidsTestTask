using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
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
        public struct PlayerMovementSetting
        {
            public float MaxInertion;
            public float RotationSpeed;
            public float InertionRaiseValue;
        }

        [System.Serializable]
        public struct Enemy
        {
            //??? ??? ?? ????????????? ?????
            public string Id;

            public float Health;
            public float Points;

            public float Speed;
        }
    }
}