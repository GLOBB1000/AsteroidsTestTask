using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Direction);
        transform.position += Direction * speed * Time.deltaTime;
    }
}
