using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : BehaviourCtrl
{
    public int maxHp = 10;
    private int hp;
    public int energy = 10;
    public float speed = 10; //基础移动速度

    public ICommand command { get; set; }
    public CircleQueue<TimeInfo2> timeQueue;
    public Dictionary<int, ISkill> skillMap;

    public AttackCtrl attackCtrl;
    private Rigidbody rb;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attackCtrl = GetComponent<AttackCtrl>();
        animator = GetComponentInChildren<Animator>();
        timeQueue = TQueueExtion.CircleQueue(3f);
        skillMap = new Dictionary<int, ISkill>();
        ISkill skill = new PSkill1();
        skillMap.Add(skill.skillID, skill);
        GetComponent<BeAttackedable>().OnGetHit += OnGetHurt;
    }
    private void OnDestroy()
    {
        GetComponent<BeAttackedable>().OnGetHit -= OnGetHurt;
    }
    void Update()
    {
        if (command != null) command.execute(this);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject prefab = (GameObject)Instantiate(Resources.Load("Prefabs/Player (2)"));
            prefab.transform.position = transform.position;
            prefab.transform.localScale = transform.localScale;
            prefab.GetComponent<PlayerShadow>().Init(timeQueue.ToStack());
        }
    }
    private void FixedUpdate()
    {
        timeQueue.Push(TimeInfo2.InfoType.Position, transform.position);
        timeQueue.Push(TimeInfo2.InfoType.Rotation, transform.rotation);
        timeQueue.Push(TimeInfo2.InfoType.AnimatorState, animator.GetCurrentAnimatorStateInfo(0).shortNameHash);
        if (!timeQueue.IsEmpty() && Time.fixedTime - timeQueue.FrontItem().triggerTime > 3)//队列非空且队头时间距当前时间间隔大于3s
        {
            timeQueue.DeQueue();
        }
    }
    public void Move()
    {
        float verticalmove = Input.GetAxisRaw("Vertical");
        float hormove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(hormove * speed*Time.fixedDeltaTime, 0,verticalmove * speed*Time.fixedDeltaTime);
        if (hormove != 0 || verticalmove != 0)
        {
            //transform.rotation = Quaternion.Euler(new Vector3(0, hormove*90+verticalmove*(-45), 0));
            transform.forward = new Vector3(hormove, 0, verticalmove);
        }
        
    }
    public void OnAttack(int skillId)
    {
        ISkill skill = skillMap[skillId];
        //攻击逻辑
        if (attackCtrl.doAttack(this, skill))
        {
            animator.Play(skill.name);
        }
        else Debug.Log("fail to use skill");
    }
    protected void OnAttackEnd()//攻击结束调用
    {
        animator.Play("Idle");
    }
    void OnGetHurt(Vector3 position,Vector3 force,int damage)
    {
        hp -= damage;
        Debug.Log("Player GetHurt");
        EventCenter.GetInstance().BraodCastEvent(EventType.PlayerHpChange, hp / maxHp);
    }
}
