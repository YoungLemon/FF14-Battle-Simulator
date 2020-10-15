using UnityEngine;

enum DamageState
{
    emerge,
    idle,
    destroy
}

public abstract class Damage : MonoBehaviour
{
    internal GameObject startObject = null;
    internal GameObject followObject = null;
    private bool isActive = false;
    internal bool IsActive
    {
        get { return isActive; }
        set { 
            isActive = value;
            if (gameObject != null)
                gameObject.SetActive(value);
        }
    }

    // 创建事件
    public void Create() {
        if (startObject != null)        // 有起始跟踪对象则转到起始对象位置
            gameObject.transform.position = new Vector3(startObject.transform.position.x ,gameObject.transform.position.y, startObject.transform.position.z);
        IsActive = true;
    }

    // 触发时产生的效果
    public abstract void Trigger();

    private void FixedUpdate()
    {
        if (followObject != null)
            transform.position = followObject.transform.position;
    }

    private void Awake()
    {
        IsActive = false;
    }
}
