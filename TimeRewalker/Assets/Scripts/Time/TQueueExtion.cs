using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class TQueueExtion 
{
    public static CircleQueue<TimeInfo2> CircleQueue(float timeLength)
    {
        int size = (int)(timeLength / Time.fixedDeltaTime);
        return new CircleQueue<TimeInfo2>(size);
    }
    public static void Push(this CircleQueue<TimeInfo2> circleQueue,TimeInfo2.InfoType infoType,object info)
    {
        if(!circleQueue.IsEmpty()&&circleQueue.RearItem().triggerTime==Time.fixedTime)//在同一时间点的不同信息
        {
            circleQueue.RearItem().infoList.Add(new KeyValuePair<TimeInfo2.InfoType, object>(infoType, info));
        }
        else//添加新的时间节点
        {
            circleQueue.EnQueue(new TimeInfo2(infoType, info));
        }
    }
    public static Stack<TimeInfo2> ToStack(this CircleQueue<TimeInfo2> queue)
    {
        Stack<TimeInfo2> stack = new Stack<TimeInfo2>();
        while(!queue.IsEmpty())
        {
            stack.Push(queue.DeQueue());
        }
        return stack;
    }
}
public struct TimeInfo2
{
    public enum InfoType
    {
        Position,
        Rotation,
        Localscale,
        AnimatorState,
        AttackPoint,
    }
    public TimeInfo2(InfoType infoType, object info)
    {
        triggerTime = Time.fixedTime;
        infoList = new List<KeyValuePair<InfoType, object>>();
        infoList.Add(new KeyValuePair<InfoType, object>(infoType, info));
    }
    public float triggerTime;
    public List<KeyValuePair<InfoType, object>> infoList;
}