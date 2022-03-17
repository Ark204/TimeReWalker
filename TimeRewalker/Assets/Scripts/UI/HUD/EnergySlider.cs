using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour
{
    private Slider energySlider;

    
    void Start()
    {
        energySlider=GetComponent<Slider>();
        //在此添加监听后 当主角血量变化事件(EventType.PlayerEnergyChange)发生时，将自动调用添加监听的函数(OnPlayerEnergyChange)
        EventCenter.GetInstance().AddListener<float>(EventType.PlayerEnergyChange,OnPlayerEnergyChange);
    }
    void OnDestroy()
    {
        //脚本销毁时，需要记得移除监听
        EventCenter.GetInstance().RemoveListener<float>(EventType.PlayerEnergyChange,OnPlayerEnergyChange);
    }
    //调用端会负责传入主角Energy/maxEnergy比值作为函数的参数(i)
    void OnPlayerEnergyChange(float i)
    {
        energySlider.value=i;
    }
}
