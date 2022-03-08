using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : BehaviourCtrl
{
    public int hp = 10;
    public float speed = 10; //基础移动速度

    public ICommand command { get; set; }
    private CircleQueue<TimeInfo2> timeQueue;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeQueue = TQueueExtion.CircleQueue(3f);
    }
    void Update()
    {
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
        if (command != null) command.execute(this);
        timeQueue.Push(TimeInfo2.InfoType.Position, transform.position);
        if (!timeQueue.IsEmpty() && Time.fixedTime - timeQueue.FrontItem().triggerTime > 3)//队列非空且队头时间距当前时间间隔大于3s
        {
            timeQueue.DeQueue();
        }
    }
    public void Move()
    {
        float verticalmove = Input.GetAxisRaw("Vertical");
        float hormove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(hormove * speed, 0,verticalmove * speed);
        //if (hormove != 0||verticalmove!=0)
        //{
        //    transform.localScale = new Vector3(hormove, 1, verticalmove);
        //}
    }
}
