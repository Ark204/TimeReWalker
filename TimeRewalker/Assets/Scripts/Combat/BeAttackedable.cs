using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeAttackedable : MonoBehaviour
{
    /// <summary>
    /// 受击事件，受攻击者向此事件中添加或移除监听函数以控制事件回调
    /// </summary>
    public event Action<Vector3, Vector3,int> OnGetHit;
    /// <summary>
    /// 攻击者将获取这个组件，并调用这个组件此函数以触发被击者的受击函数
    /// </summary>
    public virtual void OnGetHurt(Vector3 position,Vector3 force,int damage)
    {
        OnGetHit.Invoke(position, force, damage);
    }
}

