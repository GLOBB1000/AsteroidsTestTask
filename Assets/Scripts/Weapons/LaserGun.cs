using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    private const float timeToReloadLaser = 10;

    private float reloadTimer;

    [SerializeField]
    private Laser laser;

    private float Duration;

    public float FireRate { get; private set; }

    public int CountOfFire { get; private set; }

    private bool isLaserActive;

    protected override void Start()
    {
        base.Start();
        Duration = currentWeapon.Duration;
        FireRate = 0;
        CountOfFire = currentWeapon.CountOfFire;
    }
    protected override void Shoot()
    {
        laser.gameObject.SetActive(true);
        isLaserActive = true;
        FireRate = currentWeapon.FireRate;
        CountOfFire--;
    }

    private void Reload()
    {
        CountOfFire++;
        reloadTimer = timeToReloadLaser;
    }

    private void Update()
    {
        FireRate -= Time.deltaTime;
        reloadTimer -= Time.deltaTime;

        if(reloadTimer < 0)
        {
            Reload();
        }

        if (Input.GetMouseButtonDown(0) && FireRate <= 0 && CountOfFire > 0)
        {
            Shoot();
        }

        if (isLaserActive)
        {
            Duration -= Time.deltaTime;

            if(Duration <= 0)
            {
                isLaserActive = false;
                laser.gameObject.SetActive(false);
                Duration = currentWeapon.Duration;
            }
        }
    }

}
