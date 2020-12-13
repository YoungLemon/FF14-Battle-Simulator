using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public GameObject CircleTouchDamageObject;

    public static DamageManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public Damage CreateCircleTouchDamage(Vector3 pos, float size, float durationTime, int damageNum, GameObject startObject=null)
    {
        CircleTouchDamage d = Instantiate(CircleTouchDamageObject).GetComponent<CircleTouchDamage>();
        d.transform.position = new Vector3(pos.x, 0.1f, pos.z);
        d.transform.localScale = new Vector3(0, 0.01f, 0);
        d.maxSize = size;
        d.timer = durationTime;
        d.damage = damageNum;
        d.startObject = startObject;
        return d;
    }
}
