using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ITeleportable, IPlayer
{
    public Vector2 Coordinates => transform.position;
    public float Angle => transform.eulerAngles.z;

    public float CurrentSpeed => currentSpeed * 100;

    public bool IsTeleportedJustNow { get ; set; }
    public bool IsObjectInBounds { get; set; }

    [SerializeField]
    private GameSettings gameSettings;

    private float currentSpeed; 


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

        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, gameSettings.PlayerMovement.RotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward, gameSettings.PlayerMovement.RotationSpeed * Time.deltaTime);
        }

        currentSpeed = changedInertion * Time.deltaTime;

        transform.position += transform.right * currentSpeed;
    }
}
