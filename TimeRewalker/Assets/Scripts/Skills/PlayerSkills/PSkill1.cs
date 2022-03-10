using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSkill1 : ISkill
{
    private const int m_skillID = 1;
    private const float m_endTime = 0.633f;
    private const string m_name = "attack_1";
    public const float hurtTime1 = 0.315f;
    public const int attack = 1;
    public const float attackR = 3;
    public PSkill1() { }
    public int skillID => m_skillID;
    public float endTime => m_endTime;
    public string name => m_name;
    public bool onUsing(BehaviourCtrl bBehaviorCtrl)
    {
        PlayerCtrl playerCtrl = bBehaviorCtrl as PlayerCtrl;
        playerCtrl.attackCtrl.SetEffectPoint(hurtTime1, Attack1);
        return true;
    }
    /// <summary>
    /// 攻击生效点1
    /// </summary>
    /// <param name="attackCtrl">攻击释放者</param>
    void Attack1(AttackCtrl attackCtrl)
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(attackCtrl.transform.position, attackR);
        foreach (Collider2D collider2D in collider2Ds)
        {
            if (collider2D.CompareTag("Enemies"))
            {
                collider2D.GetComponent<BeAttackedable>().OnGetHurt(attackCtrl.transform.position, Vector3.zero, attack);
            }
        }
        PlayerCtrl playerCtrl = attackCtrl.GetComponent<PlayerCtrl>();
        //记录影子将回放的攻击点
        playerCtrl.timeQueue.Push(TimeInfo2.InfoType.AttackPoint, new PlayerShadow.AttackAction(Attack1RePlay));
    }
    void Attack1RePlay(PlayerShadow shadow)
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(shadow.transform.position, attackR);
        foreach (Collider2D collider2D in collider2Ds)
        {
            if (collider2D.CompareTag("Enemies"))
            {
                collider2D.GetComponent<BeAttackedable>().OnGetHurt(shadow.transform.position, Vector3.zero, attack);
            }
        }
    }
}
