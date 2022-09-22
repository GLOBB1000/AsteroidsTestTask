using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface IPlayer
    {
        public Vector2 Coordinates { get; }

        public float Angle { get; }

        public float CurrentSpeed { get; }
    }

}