using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    private Slider hpSlider;

    
    void Start()
    {
        hpSlider=GetComponent<Slider>();
        //在此添加监听后 当主角血量变化事件(EventType.PlayerHpChange)发生时，将自动调用添加监听的函数(OnPlayerHpChange)
        EventCenter.GetInstance().AddListener<float>(EventType.PlayerHpChange,OnPlayerHpChange);
    }
    void OnDestroy()
    {
        //脚本销毁时，需要记得移除监听
        EventCenter.GetInstance().RemoveListener<float>(EventType.PlayerHpChange,OnPlayerHpChange);
    }
    //调用端会负责传入主角Hp/maxHp比值作为函数的参数(i)
    void OnPlayerHpChange(float i)
    {
        hpSlider.value=i;
    }
}
