using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeAttackedable : MonoBehaviour
{
    public event Action<Vector2, Vector2> OnHit;
    public virtual void OnAttackHit(Vector2 position, Vector2 force, int damage)
    {
        OnHit?.Invoke(position,force);
    }
}

