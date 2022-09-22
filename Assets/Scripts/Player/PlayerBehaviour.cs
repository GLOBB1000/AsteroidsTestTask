using Enemies;
using System;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public static event Action OnDead;


        private void OnPlayerDead()
        {
            Debug.Log("Dead");
            gameObject.SetActive(false);

            OnDead?.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var coll = collision.collider.GetComponent<Enemy>();

            if (coll != null)
            {
                OnPlayerDead();
            }
        }
    }
}