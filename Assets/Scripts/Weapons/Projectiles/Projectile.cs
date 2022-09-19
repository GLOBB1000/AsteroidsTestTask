using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, IDestroyable
{
    public float Damage {get; set;}
    public Vector3 Direction {get; set;}

}
