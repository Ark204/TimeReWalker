using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���ͻ���:���ڴ�������ģʽ
/// </summary>
/// <typeparam name="T">����</typeparam>
public class BaseManager<T> where T : new()
{
    private static T _Instance;

    public static T GetInstance()
    {
        if (_Instance == null)
        {
            _Instance = new T();
        }
        return _Instance;
    }
}