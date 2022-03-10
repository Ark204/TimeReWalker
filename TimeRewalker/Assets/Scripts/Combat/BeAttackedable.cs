using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeAttackedable : MonoBehaviour
{
    /// <summary>
    /// �ܻ��¼����ܹ���������¼�����ӻ��Ƴ����������Կ����¼��ص�
    /// </summary>
    public event Action<Vector3, Vector3,int> OnGetHit;
    /// <summary>
    /// �����߽���ȡ���������������������˺����Դ��������ߵ��ܻ�����
    /// </summary>
    public virtual void OnGetHurt(Vector3 position,Vector3 force,int damage)
    {
        OnGetHit.Invoke(position, force, damage);
    }
}

