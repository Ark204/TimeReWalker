using System;
using System.Collections.Generic;
public delegate void CallBack();
public delegate void CallBack<T>(T arg);
public delegate void CallBack<T, X>(T arg1, X arg2);
public delegate void CallBack<T, X, Y>(T arg1, X arg2, Y arg3);
public delegate void CallBack<T, X, Y, Z>(T arg1, X arg2, Y arg3, Z arg4);
public delegate void CallBack<T, X, Y, Z, W>(T arg1, X arg2, Y arg3, Z arg4, W arg5);
public class BindHelper
{
    public static Func<T> Bind<T,T1>(Func<T1,T> func,T1 t1)
    {
        return () =>
        {
            return func(t1);
        };
    }
    public static CallBack Bind<T>(CallBack<T> func, T t)
    {
        return () =>
        {
            func(t);
        };
    }
}
public class EventCenter : BaseManager<EventCenter>
{
    private Dictionary<EventType, Delegate> m_EventTable = new Dictionary<EventType, Delegate>();
    public void AddListener(EventType eventType, CallBack callBack)
    {
        if (!m_EventTable.ContainsKey(eventType))
        {
            m_EventTable.Add(eventType, null);
        }
        Delegate d = m_EventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("�����¼�Ϊ{0}��Ӳ�ͬ����ί�У���ǰί������Ϊ{1}��Ҫ��ӵ�ί������Ϊ{2}", eventType, d.GetType(), callBack.GetType()));
        }
        m_EventTable[eventType] = (CallBack)m_EventTable[eventType] + callBack;
    }
    public void AddListener<T>(EventType eventType,CallBack<T> callBack) 
    {
        if (!m_EventTable.ContainsKey(eventType))
        {
            m_EventTable.Add(eventType, null);
        }
        Delegate d = m_EventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("�����¼�Ϊ{0}��Ӳ�ͬ����ί�У���ǰί������Ϊ{1}��Ҫ��ӵ�ί������Ϊ{2}", eventType, d.GetType(), callBack.GetType()));
        }
        m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] + callBack;
    }
    public void AddListener<X, Y>(EventType eventType, CallBack<X, Y> callBack)
    {
        if (!m_EventTable.ContainsKey(eventType))
        {
            m_EventTable.Add(eventType, null);
        }
        Delegate d = m_EventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("�����¼�Ϊ{0}��Ӳ�ͬ����ί�У���ǰί������Ϊ{1}��Ҫ��ӵ�ί������Ϊ{2}", eventType, d.GetType(), callBack.GetType()));
        }
        m_EventTable[eventType] = (CallBack<X, Y>)m_EventTable[eventType] + callBack;
    }
    public void AddListener<X, Y,Z>(EventType eventType, CallBack<X, Y,Z> callBack)
    {
        if (!m_EventTable.ContainsKey(eventType))
        {
            m_EventTable.Add(eventType, null);
        }
        Delegate d = m_EventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("�����¼�Ϊ{0}��Ӳ�ͬ����ί�У���ǰί������Ϊ{1}��Ҫ��ӵ�ί������Ϊ{2}", eventType, d.GetType(), callBack.GetType()));
        }
        m_EventTable[eventType] = (CallBack<X, Y,Z>)m_EventTable[eventType] + callBack;
    }
    public void AddListener<X, Y,Z,W>(EventType eventType, CallBack<X, Y,Z,W> callBack)
    {
        if (!m_EventTable.ContainsKey(eventType))
        {
            m_EventTable.Add(eventType, null);
        }
        Delegate d = m_EventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("�����¼�Ϊ{0}��Ӳ�ͬ����ί�У���ǰί������Ϊ{1}��Ҫ��ӵ�ί������Ϊ{2}", eventType, d.GetType(), callBack.GetType()));
        }
        m_EventTable[eventType] = (CallBack<X, Y,Z,W>)m_EventTable[eventType] + callBack;
    }
    public void AddListener<X, Y,Z,W,T>(EventType eventType, CallBack<X, Y,Z,W,T> callBack)
    {
        if (!m_EventTable.ContainsKey(eventType))
        {
            m_EventTable.Add(eventType, null);
        }
        Delegate d = m_EventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("�����¼�Ϊ{0}��Ӳ�ͬ����ί�У���ǰί������Ϊ{1}��Ҫ��ӵ�ί������Ϊ{2}", eventType, d.GetType(), callBack.GetType()));
        }
        m_EventTable[eventType] = (CallBack<X, Y,Z,W,T>)m_EventTable[eventType] + callBack;
    }
    public void RemoveListener(EventType eventEnum, CallBack callBack)
    {
        if (m_EventTable.ContainsKey(eventEnum))
        {
            Delegate d = m_EventTable[eventEnum];
            if (d == null)
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί������", eventEnum));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί��,��ǰί��Ϊ{1}��Ҫ�Ƴ����¼�Ϊ{2}", eventEnum, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("�Ƴ��¼�����û���¼���{0}", eventEnum));
        }
        m_EventTable[eventEnum] = (CallBack)m_EventTable[eventEnum] - callBack;
        if (m_EventTable[eventEnum] == null)
        {
            m_EventTable.Remove(eventEnum);
        }
    }
    public void RemoveListener<X>(EventType eventEnum, CallBack<X> callBack)
    {
        if (m_EventTable.ContainsKey(eventEnum))
        {
            Delegate d = m_EventTable[eventEnum];
            if (d == null)
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί������", eventEnum));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί��,��ǰί��Ϊ{1}��Ҫ�Ƴ����¼�Ϊ{2}", eventEnum, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("�Ƴ��¼�����û���¼���{0}", eventEnum));
        }
        m_EventTable[eventEnum] = (CallBack<X>)m_EventTable[eventEnum] - callBack;
        if (m_EventTable[eventEnum] == null)
        {
            m_EventTable.Remove(eventEnum);
        }
    }
    /// <summary>
    /// two parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="callBack"></param>
    public void RemoveListener<X, Y>(EventType eventEnum, CallBack<X, Y> callBack)
    {
        if (m_EventTable.ContainsKey(eventEnum))
        {
            Delegate d = m_EventTable[eventEnum];
            if (d == null)
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί������", eventEnum));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί��,��ǰί��Ϊ{1}��Ҫ�Ƴ����¼�Ϊ{2}", eventEnum, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("�Ƴ��¼�����û���¼���{0}", eventEnum));
        }
        m_EventTable[eventEnum] = (CallBack<X, Y>)m_EventTable[eventEnum] - callBack;
        if (m_EventTable[eventEnum] == null)
        {
            m_EventTable.Remove(eventEnum);
        }
    }
    /// <summary>
    ///  three parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <typeparam name="Z"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="callBack"></param>
    public void RemoveListener<X, Y, Z>(EventType eventEnum, CallBack<X, Y, Z> callBack)
    {
        if (m_EventTable.ContainsKey(eventEnum))
        {
            Delegate d = m_EventTable[eventEnum];
            if (d == null)
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί������", eventEnum));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί��,��ǰί��Ϊ{1}��Ҫ�Ƴ����¼�Ϊ{2}", eventEnum, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("�Ƴ��¼�����û���¼���{0}", eventEnum));
        }
        m_EventTable[eventEnum] = (CallBack<X, Y, Z>)m_EventTable[eventEnum] - callBack;
        if (m_EventTable[eventEnum] == null)
        {
            m_EventTable.Remove(eventEnum);
        }
    }
    /// <summary>
    /// four parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <typeparam name="Z"></typeparam>
    /// <typeparam name="W"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="callBack"></param>
    public void RemoveListener<X, Y, Z, W>(EventType eventEnum, CallBack<X, Y, Z, W> callBack)
    {
        if (m_EventTable.ContainsKey(eventEnum))
        {
            Delegate d = m_EventTable[eventEnum];
            if (d == null)
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί������", eventEnum));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί��,��ǰί��Ϊ{1}��Ҫ�Ƴ����¼�Ϊ{2}", eventEnum, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("�Ƴ��¼�����û���¼���{0}", eventEnum));
        }
        m_EventTable[eventEnum] = (CallBack<X, Y, Z, W>)m_EventTable[eventEnum] - callBack;
        if (m_EventTable[eventEnum] == null)
        {
            m_EventTable.Remove(eventEnum);
        }
    }
    /// <summary>
    /// five parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <typeparam name="Z"></typeparam>
    /// <typeparam name="W"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="callBack"></param>
    public void RemoveListener<X, Y, Z, W, T>(EventType eventEnum, CallBack<X, Y, Z, W, T> callBack)
    {
        if (m_EventTable.ContainsKey(eventEnum))
        {
            Delegate d = m_EventTable[eventEnum];
            if (d == null)
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί������", eventEnum));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("�Ƴ��¼������¼�{0}û�ж�Ӧ��ί��,��ǰί��Ϊ{1}��Ҫ�Ƴ����¼�Ϊ{2}", eventEnum, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("�Ƴ��¼�����û���¼���{0}", eventEnum));
        }
        m_EventTable[eventEnum] = (CallBack<X, Y, Z, W, T>)m_EventTable[eventEnum] - callBack;
        if (m_EventTable[eventEnum] == null)
        {
            m_EventTable.Remove(eventEnum);
        }
    }
    /// <summary>
    /// �㲥�¼�
    /// </summary>
    /// <param name="eventEnum"></param>
    public void BraodCastEvent(EventType eventEnum)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventEnum, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                callBack();
            }
            else
            {
                throw new Exception(string.Format("�㲥�¼������¼�{0}�в�ͬ���͵�ί��", eventEnum));
            }
        }
    }
    /// <summary>
    /// one parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="arg"></param>
    public void BraodCastEvent<X>(EventType eventEnum, X arg)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventEnum, out d))
        {
            CallBack<X> callBack = d as CallBack<X>;
            if (callBack != null)
            {
                callBack(arg);
            }
            else
            {
                throw new Exception(string.Format("�㲥�¼������¼�{0}�в�ͬ���͵�ί��", eventEnum));
            }
        }
    }
    /// <summary>
    /// two parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    public void BraodCastEvent<X, Y>(EventType eventEnum, X arg1, Y arg2)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventEnum, out d))
        {
            CallBack<X, Y> callBack = d as CallBack<X, Y>;
            if (callBack != null)
            {
                callBack(arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("�㲥�¼������¼�{0}�в�ͬ���͵�ί��", eventEnum));
            }
        }
    }
    /// <summary>
    /// three parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <typeparam name="Z"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    public void BraodCastEvent<X, Y, Z>(EventType eventEnum, X arg1, Y arg2, Z arg3)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventEnum, out d))
        {
            CallBack<X, Y, Z> callBack = d as CallBack<X, Y, Z>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("�㲥�¼������¼�{0}�в�ͬ���͵�ί��", eventEnum));
            }
        }
    }
    /// <summary>
    /// four parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <typeparam name="Z"></typeparam>
    /// <typeparam name="W"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    public void BraodCastEvent<X, Y, Z, W>(EventType eventEnum, X arg1, Y arg2, Z arg3, W arg4)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventEnum, out d))
        {
            CallBack<X, Y, Z, W> callBack = d as CallBack<X, Y, Z, W>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4);
            }
            else
            {
                throw new Exception(string.Format("�㲥�¼������¼�{0}�в�ͬ���͵�ί��", eventEnum));
            }
        }
    }
    /// <summary>
    /// five parameter
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <typeparam name="Z"></typeparam>
    /// <typeparam name="W"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="eventEnum"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    public void BraodCastEvent<X, Y, Z, W, T>(EventType eventEnum, X arg1, Y arg2, Z arg3, W arg4, T arg5)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventEnum, out d))
        {
            CallBack<X, Y, Z, W, T> callBack = d as CallBack<X, Y, Z, W, T>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                throw new Exception(string.Format("�㲥�¼������¼�{0}�в�ͬ���͵�ί��", eventEnum));
            }
        }
    }
}
