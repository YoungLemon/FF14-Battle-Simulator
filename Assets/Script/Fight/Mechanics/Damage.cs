using UnityEngine;

enum DamageState
{
    emerge,
    idle,
    destroy
}

public abstract class Damage : MonoBehaviour
{
    public GameObject followObject = null;
    protected bool isTriggered = false;

    // 触发时产生的效果
    public abstract void Trigger();

    private void FixedUpdate()
    {
        if (followObject != null)
            transform.position = followObject.transform.position;
    }
}
