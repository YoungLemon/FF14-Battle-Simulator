using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorTouchDamageInfo: DamageInfo
{
    public float radius;
    public float radiusInner;
    public float angle;

    public SectorTouchDamageInfo(GameObject fromObject, int damageNum, float displaySecond, float radius, float radiusInner = 0, float angle = 360)
    {
        this.fromObject = fromObject;
        this.damageNum = damageNum;
        this.radius = radius;
        this.displaySecond = displaySecond;
        this.radiusInner = radiusInner;
        this.angle = angle;
    }

    public SectorTouchDamageInfo(Vector3 fromPosition, int damageNum, float displaySecond, float radius, float radiusInner = 0, float angle = 360)
    {
        this.fromPosition = fromPosition;
        this.damageNum = damageNum;
        this.radius = radius;
        this.displaySecond = displaySecond;
        this.radiusInner = radiusInner;
        this.angle = angle;
    }
}
