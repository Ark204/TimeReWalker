using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Cinemachine.Editor;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private static CameraCtrl _camInstance;             //当前类实例
    private static CinemachineVirtualCamera Cam;        //相机组件
    
    private float zoomDir;                              //镜头缩放方向
    private float targetSize;                           //目标缩放尺寸
    private float zoomSpeed = 8f;                       //缩放速度
    
    private float _MAX_SIZE = 12f;                      //镜头最大尺寸(最远)
    private float _MIN_SIZE = 6f;                       //镜头最小尺寸(最近)
    private void Start()
    {
        Cam = GetComponent<CinemachineVirtualCamera>();
        targetSize = Cam.m_Lens.OrthographicSize;       //默认初始缩放即为当前镜头大小
    }

    private void Awake()
    {
        if (_camInstance == null)
            _camInstance = this;
    }

    private void Update()
    {
        ScrollToZoom();
    }

    private void ScrollToZoom()
    {
        zoomDir=Input.GetAxis("Mouse ScrollWheel"); //输入滚轮方向
        targetSize = Cam.m_Lens.OrthographicSize - zoomDir * zoomSpeed;//更改目标缩放大小
        if (targetSize > _MAX_SIZE)                 //限制缩放大小在指定取值范围内
            targetSize = _MAX_SIZE;
        else if (targetSize < _MIN_SIZE) 
            targetSize = _MIN_SIZE;
        if (Cam.m_Lens.OrthographicSize < targetSize - 0.1f ||
            Cam.m_Lens.OrthographicSize > targetSize + 0.1f)//当目前镜头大小和目标镜头大小不符合则缩放镜头
            Cam.m_Lens.OrthographicSize = Mathf.Lerp(Cam.m_Lens.OrthographicSize, targetSize, 0.4f);


    }
}
