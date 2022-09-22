using Core;
using Enemies;
using UnityEngine;

namespace Weapons
{
    public class Bullet : Projectile, IDestroyable
    {
        [SerializeField]
        private float speed;

        private float lifeTime = 5;

        private float lifeTimer;

        // Update is called once per frame
        void Update()
        {
            transform.position += Direction * speed * Time.deltaTime;

            if (gameObject.activeInHierarchy)
            {
                lifeTimer -= Time.deltaTime;

                if (lifeTimer <= 0)
                {
                    gameObject.SetActive(false);
                    lifeTimer = lifeTime;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var enemy = collision.collider.GetComponent<Enemy>();

            if (enemy == null)
                return;

            gameObject.SetActive(false);
        }
    }
}