using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using FFSimulator_client;

public class ChatManager : MonoBehaviour
{

    public static ChatManager Instance = null;

    public InputField chatInput;
    public Text chatText;
    public ScrollRect scrollRect;

    private string messageClient = "";
    [HideInInspector] public string messageServer = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FNet.Instance.RegisterChatroom();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && chatInput.text != "")
        {
            FNet.Instance.SendMessage(chatInput.text);
            chatInput.text = "";
            chatInput.ActivateInputField();
        }
        if (messageServer != messageClient)
        {
            AddMessage(messageServer, false);
            messageClient = messageServer;
        }
    }

    public void AddMessage(string message, bool isSystemMessage)
    {
        if (isSystemMessage)
        {
            message = "<color=gray>" + message + "</color>";
        }
        message = "\n <color=white>[" + DateTime.Now.Hour +  ":" + DateTime.Now.Minute + "]</color>" + message;
        chatText.text += message;
        Canvas.ForceUpdateCanvases();       //关键代码
        scrollRect.verticalNormalizedPosition = 0f;  //关键代码
        Canvas.ForceUpdateCanvases();   //关键代码
    }
}