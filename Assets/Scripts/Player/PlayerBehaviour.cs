using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IPlayer
{
    public Vector2 Coordinates { get => transform.position; set => transform.position = value; }

    [SerializeField]
    private List<Weapon> weapons;

    private void Update()
    {
        
    }
}
