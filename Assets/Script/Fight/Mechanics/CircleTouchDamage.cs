using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleTouchDamage : TouchDamage
{
    private DamageState state = DamageState.emerge;
    public float maxSize = 1f;
    public float timer = 0f;
    public int damage = 0;

    public override void Trigger()
    {
        // 对范围内的玩家扣血
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach(PlayerController p in players)
        {
            if (Vector3.Distance(new Vector3(p.transform.position.x, 0, p.transform.position.z), 
                new Vector3(transform.position.x, 0, transform.position.z)) 
                <= transform.localScale.x / 2)
            {
                p.ChangeHp(p.CurHp - damage);
            }
        }
        state = DamageState.destroy;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        switch (state)      // 根据状态表现动画或触发
        {
            case DamageState.emerge:    // 出现动画
                transform.localScale += new Vector3(Time.deltaTime * 20f, 0, Time.deltaTime * 20f);
                if (transform.localScale.x >= maxSize)
                {
                    transform.localScale = new Vector3(maxSize, 0.01f, maxSize);
                    state = DamageState.idle;
                }
                break;
            case DamageState.idle:      // 触发
                if (timer <= 0f) Trigger();
                break;
            case DamageState.destroy:   // 消失动画
                Color c = GetComponent<MeshRenderer>().material.color;
                c.a -= Time.deltaTime * 5f;
                if (c.a <= 0) Destroy(gameObject);
                else GetComponent<MeshRenderer>().material.color = c;
                break;
        }
    }


}
