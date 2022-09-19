using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    public float Damage { get; set; }

    public abstract Vector3 Direction { get; set; }
}
