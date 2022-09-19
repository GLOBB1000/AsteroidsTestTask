using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ScreenBordersTeleportation : MonoBehaviour
{
    private Vector2 borders;
    private Vector2 screenCenter;

    private List<Vector2> bordersCoordinates = new List<Vector2>();

    private ITeleportable lastTeleportableObject;

    private void Start()
    {
        borders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        bordersCoordinates.Add(new Vector2(borders.x, 0));
        bordersCoordinates.Add(new Vector2(-borders.x, 0));
        bordersCoordinates.Add(new Vector2(0, borders.y));
        bordersCoordinates.Add(new Vector2(0, -borders.y));
    }

    void Update()
    {
        foreach (var border in bordersCoordinates)
        {
            var colliders = Physics2D.OverlapBoxAll(border, new Vector2(Mathf.Abs(border.y * 4), Mathf.Abs(border.x)), 0);

            for (int i = 0; i < colliders.Length; i++)
            {
                var teleportable = colliders[i].GetComponent<ITeleportable>();
                var destroyable = colliders[i].GetComponent<IDestroyable>();

                if (teleportable != null && IsTeleportableFound(colliders[i]) && !teleportable.IsTeleportedJustNow)
                {
                    teleportable.IsObjectInBounds = true;

                    var collider = colliders[i];
                    collider.gameObject.transform.position = GetNewPosition(collider.gameObject.transform.position);

                    teleportable.IsTeleportedJustNow = true;
                    lastTeleportableObject = teleportable;
                    StartCoroutine(TeleportationReset(lastTeleportableObject));
                }

                if(destroyable != null)
                {
                    var proj = (Projectile)destroyable;
                    

                    if (proj != null)
                    {
                        proj.gameObject.SetActive(false);
                    }

                    else
                    {
                        DestroyObject(destroyable);
                    }
                }

                else
                {
                    if(lastTeleportableObject != null)
                    {
                        lastTeleportableObject.IsObjectInBounds = false;
                        StopCoroutine(TeleportationReset(lastTeleportableObject));
                    }
                }
            }
        }
    }

    public Vector3 GetNewPosition(Vector3 position)
    {
        Vector3 newPos = new Vector3(screenCenter.x - position.x, screenCenter.y - position.y, 0);

        return newPos - (newPos * 0.01f);
    }

    private bool IsTeleportableFound(Collider2D collider)
    {
        var teleportable = collider.GetComponent<ITeleportable>();

        if(teleportable != null)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            if (GeometryUtility.TestPlanesAABB(planes, collider.bounds))
                return true;
            else
                return false;
        }

        else
            return false;
        
    }

    private IEnumerator TeleportationReset(ITeleportable teleportable)
    {
        yield return new WaitUntil(() => teleportable.IsObjectInBounds == false);
        teleportable.IsTeleportedJustNow = false;
    }

    private void DestroyObject(IDestroyable destroyable)
    {
        var gameObj = destroyable switch
        {
            _ => (Enemy)destroyable
        };

        Destroy(gameObj.gameObject);
    }
}
