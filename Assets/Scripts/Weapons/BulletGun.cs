using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : Weapon
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Shoot()
    {
        var projectile = objectsPool.GetPooledObject();
        projectile.SetActive(true);
        projectile.transform.position = transform.position;

        var component = projectile.GetComponent<Projectile>();

        component.Direction = transform.right;
        component.Damage = currentWeapon.Damage;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && cooldown <= 0)
        {
            Shoot();
            cooldown = currentWeapon.FireRate;
        }
    }
}