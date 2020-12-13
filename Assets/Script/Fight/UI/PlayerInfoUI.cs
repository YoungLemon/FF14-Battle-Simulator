using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    [Header("UI相关")]
    public Slider hpBar = null;
    public Text nicknameText = null;

    [HideInInspector] public PlayerController player = null;

    private void Start()
    {
        nicknameText.text = player.nickname;
    }

    void Update()
    {
        hpBar.value = (float)player.CurHp / player.MaxHp;
    }
}
