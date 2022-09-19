using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ITeleportable
{
    public bool IsTeleportedJustNow { get ; set; }
    public bool IsObjectInBounds { get; set; }

    [SerializeField]
    private GameSettings gameSettings;


    private float inertion = 0;
    private bool isMoving = false;

    private float InertionChanges()
    {
        inertion = Mathf.Clamp(inertion, 0, gameSettings.PlayerMovement.MaxInertion);

        if (isMoving)
        {
            inertion += gameSettings.PlayerMovement.InertionRaiseValue;
        }

        else
        {
            inertion -= gameSettings.PlayerMovement.InertionRaiseValue;
        }

        return Mathf.Clamp(inertion, 0, gameSettings.PlayerMovement.MaxInertion);
    }

    void Update()
    {
        var changedInertion = InertionChanges();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, gameSettings.PlayerMovement.RotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward, gameSettings.PlayerMovement.RotationSpeed * Time.deltaTime);
        }

        transform.position += transform.right * changedInertion * Time.deltaTime;
    }
}
