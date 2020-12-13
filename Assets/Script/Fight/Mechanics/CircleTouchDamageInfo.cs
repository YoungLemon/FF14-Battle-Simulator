using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTouchDamageInfo: DamageInfo
{
    public float radius;

    public CircleTouchDamageInfo(GameObject fromObject, int damageNum, float displaySecond, float radius)
    {
        this.fromObject = fromObject;
        this.damageNum = damageNum;
        this.radius = radius;
        this.displaySecond = displaySecond;
    }

    public CircleTouchDamageInfo(Vector3 fromPosition, int damageNum, float displaySecond, float radius)
    {
        this.fromPosition = fromPosition;
        this.damageNum = damageNum;
        this.radius = radius;
        this.displaySecond = displaySecond;
    }
}
