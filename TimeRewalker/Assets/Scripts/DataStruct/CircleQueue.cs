using System;

public class CircleQueue<T>
{
    /// <summary>
    /// ��������
    /// </summary>
    private T[] _queue;
    /// <summary>
    /// ��������
    /// </summary>
    private int _front;
    /// <summary>
    /// ��β����
    /// </summary>
    private int _rear;
    /// <summary>
    /// ���е��ڴ��С����ʵ�ʿ��ô�СΪ_capacity-1
    /// </summary>
    private int _capacity;

    public CircleQueue(int queueSize)
    {
        if (queueSize < 1)
            throw new IndexOutOfRangeException("����Ķ��г��Ȳ���С��1��");

        //���ö�������
        _capacity = queueSize;

        //������������
        _queue = new T[queueSize];

        //��ʼ�����׺Ͷ�β����
        _front = _rear = 0;
    }
    /// <summary>
    /// ���һ��Ԫ��
    /// </summary>
    /// <param name="item"></param>
    public void EnQueue(T item)
    {
        //��������
        if (GetNextRearIndex() == _front)
        {
            //��������
            T[] newQueue = new T[2 * _capacity];

            if (newQueue == null)
                throw new ArgumentOutOfRangeException("�����������󣬳���ϵͳ�ڴ��С��");
            //����������δ����
            if (_front == 0)
            {
                //���ɶ�����������ת�Ƶ��¶���������
                Array.Copy(_queue, newQueue, _capacity);
            }
            else
            {
                //������л��ƣ����追���ٴΣ�
                //��һ�ν��������ɶ���������󳤶ȵ����ݿ������¶���������
                Array.Copy(_queue, _front, newQueue, _front, _capacity - _rear - 1);
                //�ڶ��ν��ɶ���������ʼλ������β�����ݿ������¶���������
                Array.Copy(_queue, 0, newQueue, _capacity, _rear + 1);
                //����β������Ϊ�¶������������
                _rear = _capacity + 1;
            }

            _queue = newQueue;
            _capacity *= 2;
        }
        //�ۼӶ�β����������ӵ�ǰ��
        _rear = GetNextRearIndex();
        _queue[_rear] = item;
    }

    /// <summary>
    /// ��ȡ����Ԫ��
    /// </summary>
    /// <returns></returns>
    public T FrontItem()
    {
        if (IsEmpty())
            throw new ArgumentOutOfRangeException("����Ϊ�ա�");

        return _queue[GetNextFrontIndex()];
    }

    /// <summary>
    /// ��ȡ��βԪ��
    /// </summary>
    /// <returns></returns>
    public T RearItem()
    {
        if (IsEmpty())
            throw new ArgumentOutOfRangeException("����Ϊ�ա�");

        return _queue[_rear];
    }

    /// <summary>
    /// ����һ��Ԫ��
    /// </summary>
    /// <returns></returns>
    public T DeQueue()
    {
        if (IsEmpty())
            throw new ArgumentOutOfRangeException("����Ϊ�ա�");

        _front = GetNextFrontIndex();
        return _queue[_front];
    }
    /// <summary>
    /// �����Ƿ�Ϊ��
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return _front == _rear;
    }
    /// <summary>
    /// ��ȡ��һ������
    /// </summary>
    /// <returns></returns>
    private int GetNextRearIndex()
    {
        if (_rear + 1 == _capacity)
        {
            return 0;
        }
        return _rear + 1;
    }
    /// <summary>
    /// ��ȡ��һ������
    /// </summary>
    /// <returns></returns>
    private int GetNextFrontIndex()
    {
        if (_front + 1 == _capacity)
        {
            return 0;
        }
        return _front + 1;
    }
}
