using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

using FFSimulator_client;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public string nickname;

    [Header("数值相关")]
    public float MoveSpeed;
    public int MaxHp;
    
    private int curHp;
    public int CurHp
    {
        get { return curHp; }
        set { 
            curHp = Mathf.Clamp(value, 0, MaxHp);
            if (curHp <= 0)
            {
                Die();
            }
        }
    }

    // 镜头
    private Camera RealCamera;
    private CinemachineFreeLook CinemachineCamera;

    // 逻辑
    // 单机下，IsMine默认为true
    public bool IsMine { get; private set; } = true;

    private void Start()
    {
        if (IsMine)
        {
            RealCamera = Camera.main;
            CinemachineCamera = GameObject.Find("CM FreeLook1").GetComponent<CinemachineFreeLook>();
            CinemachineCamera.Follow = transform;
            CinemachineCamera.LookAt = transform;
        }
    }

    private void Update()
    {
        if (!IsMine) CurHp = FNet.Instance.GetHp(nickname);
    }

    void FixedUpdate()
    {
        UpdatePosition();
        if (IsMine) SetCamera();
    }

    private void OnDestroy()
    {
        PlayerInfoManager.Instance.RemovePlayerInfo(nickname);
    }

    public void Init(string nickname)
    {
        this.nickname = nickname;
        PlayerInfoManager.Instance.AddPlayerInfo(nickname);
        if (FNet.Instance.nickname == nickname)
        {
            IsMine = true;
            CurHp = MaxHp;
            FNet.Instance.SetHp(CurHp);
            FNet.Instance.SetPosition(transform.position);
        }
        else
        {
            IsMine = false;
            CurHp = FNet.Instance.GetHp(nickname);
            transform.position = FNet.Instance.GetPosition(nickname);
        }
    }

    private void UpdatePosition()
    {
        Vector3 move;
        if (IsMine)
        {
            if (transform.position.y <= -10)
            {   // 坠落判定
                CurHp = 0;
                return;
            }
            move = Quaternion.AngleAxis(RealCamera.gameObject.transform.rotation.eulerAngles.y, Vector3.up) * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * MoveSpeed * Time.fixedDeltaTime;
            transform.position += move;
            if (move.magnitude > 0)
                transform.rotation = Quaternion.FromToRotation(Vector3.forward, move);
            // FNet.Instance.SetPosition(transform.position);
        }
        else
            transform.position = FNet.Instance.GetPosition(nickname);
    }

    private void SetCamera()
    {
        if (Input.GetKey(KeyCode.Mouse1))
            CinemachineCamera.m_XAxis.m_InputAxisName = "Mouse X";
        else
        {
            CinemachineCamera.m_XAxis.m_InputAxisName = null;
            CinemachineCamera.m_XAxis.m_InputAxisValue = 0;
        }
    }

    /// <summary>
    /// 修改血量
    /// </summary>
    /// <param name="TargetHp"></param>
    public void ChangeHp(int TargetHp)
    {
        if (IsMine)
        {
            CurHp = TargetHp;
            // FNet.Instance.SetHp(CurHp);
        }
    }

    /// <summary>
    /// 死亡效果
    /// </summary>
    public void Die()
    {
        if (IsMine)
        {
            CurHp = MaxHp;
            transform.position = FightManager.Instance.GenerateRespawnPos();
        }
        ChatManager.Instance.AddMessage(nickname + "被击败了！", true);
    }
}
