using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    void execute(BehaviourCtrl behaviorCtrl);
}
public class RunCommand : ICommand
{
    public void execute(BehaviourCtrl behaviorCtrl)
    {
        PlayerCtrl player = behaviorCtrl as PlayerCtrl;
        player.Move();
    }
}
//public class Skill1Command:ICommand
//{
//    private int skillId;
//    public Skill1Command(int Id)
//    {
//        skillId = Id;
//    }
//    public void execute(BBehaviorCtrl behaviorCtrl)
//    { 
//        behaviorCtrl.onAttack(skillId);
//    }
//}
