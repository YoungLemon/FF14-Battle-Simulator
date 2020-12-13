using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using FFSimulator_client;

public class LoginManager : MonoBehaviour
{
    public InputField nicknameInput = null;
    public InputField serverIPInput = null;

    private void Start()
    {
        if (serverIPInput != null)
            serverIPInput.text = "127.0.0.1";
    }
    private void Update()
    {
        if (FNet.Instance.connectionState != ConnectionState.OFFLINE)
        {
            SceneManager.LoadScene("Fight");
        }
    }

    /// <summary>
    /// 通过UI按钮的click事件触发
    /// </summary>
    public void Login()
    {
        if (nicknameInput != null && nicknameInput.text != "")
        {
            Debug.Log(serverIPInput.text);
            FNet.Instance.Login(nicknameInput.text, serverIPInput.text);
        }
    }
}
