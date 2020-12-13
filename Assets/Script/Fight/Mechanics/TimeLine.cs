using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FFSimulator_client;

public class TimeLine : MonoBehaviour
{

    private Queue<float> timeQueue = new Queue<float>();
    private Queue<DamageInfo> damageQueue = new Queue<DamageInfo>();
    public float timer = 0f;
    public bool isPlaying = false;

    void Update()
    {
        if (isPlaying)
        {
            if (timeQueue.Count <= 0)
            {   // 时间轴结束
                ResetVariable();
            }
            else
            {
                timer += Time.deltaTime;            // 时间推移
                if (timeQueue.Peek() <= timer)      // 判断最近的伤害事件是否到达时间
                {
                    timeQueue.Dequeue();
                    damageQueue.Dequeue().Instanciate();
                }
            }
        }
    }

    public void AddDamage(float startTime, DamageInfo damage)
    {
        timeQueue.Enqueue(startTime);
        damageQueue.Enqueue(damage);
    }

    public void ResetVariable()
    {
        timeQueue.Clear();
        damageQueue.Clear();
        timer = 0f;
        isPlaying = false;
        FNet.Instance.EndPlaying();
    }
}
