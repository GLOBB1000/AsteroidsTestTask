using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeleport
{
    public event Action<ITeleportable> OnBorderCross;
}
