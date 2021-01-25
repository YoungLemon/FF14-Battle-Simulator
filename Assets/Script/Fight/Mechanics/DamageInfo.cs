using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageInfo
{
    public int damageNum;
    public Vector3 fromPosition;
    public GameObject fromObject = null;
    public float displaySecond;

    public void Instanciate()
    {
        DamageFactory.Instance.InstanciateDamage(this);
    }
}
