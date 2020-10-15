using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine : MonoBehaviour
{

    private Queue<float> timeQueue = new Queue<float>();
    private Queue<Damage> damageQueue = new Queue<Damage>();
    public float timer = 0f;
    public bool isPlaying = false;

    void Update()
    {
        if (isPlaying)
        {
            if (timeQueue.Count <= 0)
            {
                Reset();
            }
            else
            {
                timer += Time.deltaTime;            // 时间推移
                if (timeQueue.Peek() <= timer)      // 判断最近的伤害事件是否到达时间
                {
                    timeQueue.Dequeue();
                    damageQueue.Dequeue().Create();
                    PlayerController[] players = FindObjectsOfType<PlayerController>();
                    // AddDamage(timer + 0.5f, DamageManager.Instance.CreateCircleTouchDamage(Vector3.zero, 2, 0.4f, 10, players[0].gameObject));      // 测试用
                }
            }
        }
    }

    public void AddDamage(float startTime, Damage damage)
    {
        timeQueue.Enqueue(startTime);
        damageQueue.Enqueue(damage);
    }

    public void Reset()
    {
        timeQueue.Clear();
        damageQueue.Clear();
        timer = 0f;
        isPlaying = false;
    }
}
