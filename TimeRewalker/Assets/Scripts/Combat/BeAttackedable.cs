using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeAttackedable : MonoBehaviour
{
    /// <summary>
    /// �ܵ������ص��¼���arg1Ϊ���������꣬arg2Ϊ������,arg3Ϊ�����˺�
    /// </summary>
    public event Action<Vector3, Vector3,int> OnGetHit;
}

