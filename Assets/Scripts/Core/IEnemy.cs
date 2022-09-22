using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public GameSettings Settings { get; set; }
    public string Id { get; set; }
}
