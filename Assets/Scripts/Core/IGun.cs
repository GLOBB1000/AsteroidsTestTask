using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    public abstract void Shoot();
    public float CoolDown();
}