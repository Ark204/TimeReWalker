using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeAttackedable : MonoBehaviour
{
    /// <summary>
    /// 受到攻击回调事件，arg1为攻击者坐标，arg2为击退力,arg3为攻击伤害
    /// </summary>
    public event Action<Vector3, Vector3,int> OnGetHit;
}

