using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFactory : MonoBehaviour
{
    public GameObject CircleTouchDamageObject;

    public static DamageFactory Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void InstanciateDamage(DamageInfo info)
    {
        if (info is CircleTouchDamageInfo)
        {
            CircleTouchDamageInfo ctdInfo = info as CircleTouchDamageInfo;
            Vector3 pos;
            CircleTouchDamage d;
            if (ctdInfo.fromObject != null)
            {
                pos = new Vector3(ctdInfo.fromObject.transform.position.x, 0, ctdInfo.fromObject.transform.position.z);
            }
            else
            {
                pos = ctdInfo.fromPosition;
            }
            d = Instantiate(CircleTouchDamageObject, pos, Quaternion.identity).GetComponent<CircleTouchDamage>();
            d.radius = ctdInfo.radius;
            d.radiusInner = 0;
            d.anglefov = 360;
            d.timer = ctdInfo.displaySecond;
            d.damage = ctdInfo.damageNum;
            d.transform.SetParent(transform);
        }
        else if (info is RingTouchDamageInfo)
        {
            RingTouchDamageInfo rtdInfo = info as RingTouchDamageInfo;
            Vector3 pos;
            CircleTouchDamage d;
            if (rtdInfo.fromObject != null)
            {
                pos = new Vector3(rtdInfo.fromObject.transform.position.x, 0, rtdInfo.fromObject.transform.position.z);
            }
            else
            {
                pos = rtdInfo.fromPosition;
            }
            d = Instantiate(CircleTouchDamageObject, pos, Quaternion.identity).GetComponent<CircleTouchDamage>();
            d.radius = rtdInfo.radius;
            d.radiusInner = rtdInfo.radiusInner;
            d.anglefov = 360;
            d.timer = rtdInfo.displaySecond;
            d.damage = rtdInfo.damageNum;
            d.transform.SetParent(transform);
        }
    }
}
