using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    public delegate void AttackAction(PlayerShadow shadow);
    public Stack<TimeInfo2> timeStack2 { get; private set; }
    public float timer { get;private set; }
    private Animator animator;
    public void Init(Stack<TimeInfo2> timePoints)
    {
        animator = GetComponentInChildren<Animator>();
        timeStack2 = timePoints;
        timer = 0f;
        StartCoroutine(DestorySelf(3));
    }
    IEnumerator DestorySelf(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timeStack2!=null && timeStack2.Count>0&& Time.fixedTime - timeStack2.Peek().triggerTime <= 2 * timer)
        {
            foreach(var item in timeStack2.Pop().infoList)
            {
                ReadInfo(item);
            }
        }
    }
    void ReadInfo(KeyValuePair<TimeInfo2.InfoType,object> timeInfo)
    {
        switch (timeInfo.Key)
        {
            case TimeInfo2.InfoType.Position:
                {
                    Vector3 vector = (Vector3)timeInfo.Value;
                    transform.position = vector; break;
                }
            case TimeInfo2.InfoType.Rotation:
                {
                    transform.rotation = (Quaternion)timeInfo.Value;break;
                }
            case TimeInfo2.InfoType.Localscale:
                {
                    transform.localScale = (Vector3)timeInfo.Value; break;
                }
            case TimeInfo2.InfoType.AnimatorState:
                {
                    animator.Play((int)(timeInfo.Value)); break;
                }
            case TimeInfo2.InfoType.AttackPoint:
                {
                    AttackAction action = timeInfo.Value as AttackAction;
                    action?.Invoke(this); break;
                }
            default: break;
        }
    }
}
