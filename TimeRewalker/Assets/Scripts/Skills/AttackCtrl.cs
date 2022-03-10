using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackCtrl : MonoBehaviour
{
    public delegate void AttackAction(AttackCtrl attackCtrl);
    public delegate void AttackAction_0(BehaviourCtrl bBehaviorCtrl);
    private bool isAttacking ;
    public List<int> allowSkills;//技能释放过程中允许连招的技能列表
    public void reset()
    {
        isAttacking = false;
    }
    public void Init()
    {
        allowSkills = new List<int>();
        isAttacking = false;
    }
    public void Interrupt()
    {
        StopAllCoroutines();//停止所有协程
        OnEnd();
        Debug.Log("Interrupt");
    }
    public bool doAttack(BehaviourCtrl bBehaviorCtrl,ISkill skill)
    {
        if (isAttacking)
        {
            if (!allowSkills.Contains(skill.skillID)) return false;
            else Interrupt();//中断
        }
        //使用技能(由代理设置攻击生效点)
        if (!skill.onUsing(bBehaviorCtrl)) return false;
        //发起攻击
        isAttacking = true;
        //设置攻击结束点
        StartCoroutine(End(skill.endTime));
        return true;
    }
    /// <summary>
    /// 设置攻击过程中攻击生效点
    /// </summary>
    /// <param name="time">生效时间</param>
    /// <param name="unityAction">生效时回调的函数</param>
    public void SetEffectPoint(float time, AttackAction unityAction)
    {
        StartCoroutine(Effect(time, unityAction, this));
    }
    public void SetEffectPoint(float time, AttackAction_0 unityAction)
    {
        StartCoroutine(Effect(time, unityAction, this.GetComponent<BehaviourCtrl>()));
    }
    private IEnumerator Effect(float time, AttackAction unityAction, AttackCtrl attackCtrl)
    {
        yield return new WaitForSecondsRealtime(time);
        unityAction?.Invoke(attackCtrl);
    }
    private IEnumerator Effect(float time, AttackAction_0 unityAction, BehaviourCtrl attackCtrl)
    {
        yield return new WaitForSecondsRealtime(time);
        unityAction?.Invoke(attackCtrl);
    }
    private IEnumerator End(float endTime)
    {
        yield return new WaitForSecondsRealtime(endTime);
        OnEnd();
        Debug.Log("End");
    }
    void OnEnd()
    {
        reset();
        allowSkills.Clear();//清空连招列表
        SendMessage("OnAttackEnd");
    }
}
