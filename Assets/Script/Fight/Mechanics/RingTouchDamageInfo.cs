using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTouchDamageInfo: DamageInfo
{
    public float radius;
    public float radiusInner;

    public RingTouchDamageInfo(GameObject fromObject, int damageNum, float displaySecond, float radiusInner, float radius = 20)
    {
        this.fromObject = fromObject;
        this.damageNum = damageNum;
        this.radius = radius;
        this.displaySecond = displaySecond;
        this.radiusInner = radiusInner;
    }

    public RingTouchDamageInfo(Vector3 fromPosition, int damageNum, float displaySecond, float radiusInner, float radius = 20)
    {
        this.fromPosition = fromPosition;
        this.damageNum = damageNum;
        this.radius = radius;
        this.displaySecond = displaySecond;
        this.radiusInner = radiusInner;
    }
}
