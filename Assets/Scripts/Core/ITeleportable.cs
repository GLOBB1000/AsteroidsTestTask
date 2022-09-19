using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeleportable
{
    public bool IsTeleportedJustNow { get; set; }
    public bool IsObjectInBounds { get; set; } 
}
