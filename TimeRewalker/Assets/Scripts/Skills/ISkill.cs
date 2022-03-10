using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill 
{
    public int skillID { get; }
    public float endTime { get; }
    public string name { get; }
    /// <summary>
    /// ʹ�ü���ʱ���ô˺��������ڴ����ù��������еĹ�����Ч��
    /// </summary>
    /// <param name="attackCtrl">�����ͷ���</param>
    public bool onUsing(BehaviourCtrl bBehaviorCtrl);
}