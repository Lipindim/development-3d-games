using UnityEngine;
using System;

[Serializable]
public struct EnemyPrototypeStruct
{
    public GameObject EnemyPrototype;
    public Vector3 StartPosition;
    public float VisionRange;
    public float VisionAngle;
    public LayerMask LayerMask;
}
