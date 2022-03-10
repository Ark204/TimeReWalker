using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill 
{
    public int skillID { get; }
    public float endTime { get; }
    public string name { get; }
    /// <summary>
    /// 使用技能时调用此函数，请在此设置攻击过程中的攻击生效点
    /// </summary>
    /// <param name="attackCtrl">攻击释放者</param>
    public bool onUsing(BehaviourCtrl bBehaviorCtrl);
}