using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackCtrl : MonoBehaviour
{
    public delegate void AttackAction(AttackCtrl attackCtrl);
    public delegate void AttackAction_0(BehaviourCtrl bBehaviorCtrl);
    private bool isAttacking ;
    public List<int> allowSkills;//�����ͷŹ������������еļ����б�
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
        StopAllCoroutines();//ֹͣ����Э��
        OnEnd();
        Debug.Log("Interrupt");
    }
    public bool doAttack(BehaviourCtrl bBehaviorCtrl,ISkill skill)
    {
        if (isAttacking)
        {
            if (!allowSkills.Contains(skill.skillID)) return false;
            else Interrupt();//�ж�
        }
        //ʹ�ü���(�ɴ������ù�����Ч��)
        if (!skill.onUsing(bBehaviorCtrl)) return false;
        //���𹥻�
        isAttacking = true;
        //���ù���������
        StartCoroutine(End(skill.endTime));
        return true;
    }
    /// <summary>
    /// ���ù��������й�����Ч��
    /// </summary>
    /// <param name="time">��Чʱ��</param>
    /// <param name="unityAction">��Чʱ�ص��ĺ���</param>
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
        allowSkills.Clear();//��������б�
        SendMessage("OnAttackEnd");
    }
}
