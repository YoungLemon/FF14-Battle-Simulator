using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        TimeLine tl = gameObject.AddComponent<TimeLine>();
        tl.AddDamage(0f, DamageManager.Instance.CreateCircleTouchDamage(Vector3.zero, 2, 0.4f, 10));
        tl.isPlaying = true;
    }
}
