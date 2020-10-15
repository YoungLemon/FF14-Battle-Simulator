using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public CinemachineFreeLook CinemacineCamera;
    public Camera RealCamera;
    public float MoveSpeed;
    public float MaxHp;
    
    private float curHp;
    public float CurHp
    {
        get { return curHp; }
        set { curHp = Mathf.Clamp(value, 0, MaxHp); }
    }

    void FixedUpdate()
    {
        Vector3 move = Quaternion.AngleAxis(RealCamera.gameObject.transform.rotation.eulerAngles.y, Vector3.up) * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * MoveSpeed;
        transform.position += move;
        if (move.magnitude > 0)
            transform.rotation = Quaternion.FromToRotation(Vector3.forward, move);

        if (Input.GetKey(KeyCode.Mouse1))
            CinemacineCamera.m_XAxis.m_InputAxisName = "Mouse X";
        else
        {
            CinemacineCamera.m_XAxis.m_InputAxisName = null;
            CinemacineCamera.m_XAxis.m_InputAxisValue = 0;
        }
            
    }
}
