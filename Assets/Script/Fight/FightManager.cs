using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using FFSimulator_client;

public class FightManager : MonoBehaviour
{

    public static FightManager Instance = null;

    public Text countDownText;
    public GameObject playerPrefab;

    public Dictionary<string, PlayerController> players = new Dictionary<string, PlayerController>();

    TimeLine timeLine = null;

    private void Awake()
    {
        players.Clear();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        timeLine = gameObject.AddComponent<TimeLine>();
    }

    private void Update()
    {
        /// 联机代码
        //if (FNet.Instance.connectionState != ConnectionState.OFFLINE)
        //{
        //    CheckPlayerChanged();
        //    if (FNet.Instance.connectionState == ConnectionState.PLAYING && timeLine.isPlaying == false)
        //    {   // 接收到服务器开始执行时间轴的命令
        //        StartCoroutine(CountDown());
        //        InitTimeLine(60, 3);
        //        timeLine.isPlaying = true;
        //    }
        //    if (Input.GetKeyDown(KeyCode.F1))
        //    {   // 告知服务器即将开始时间轴
        //        FNet.Instance.StartPlaying();
        //    }
        //}

        /// 单机代码
        if (Input.GetKeyDown(KeyCode.F1))
        {   // 开始游戏
            StartCoroutine(CountDown());
            InitTimeLine(60, 3);
            timeLine.isPlaying = true;
        }
    }

    private void OnDestroy()
    {
        FNet.Instance.Quit();
    }

    // 倒计时
    IEnumerator CountDown()
    {
        // 倒计时文本
        countDownText.text = "3";
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        yield return new WaitForSeconds(1);
        countDownText.text = "";
    }

    private void InitTimeLine(int durationSecond, int delaySecond)
    {
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        // 时间轴内容
        switch (DateTime.Now.Minute % 3)
        {
            case 0:
                timeLine.AddDamage(delaySecond + 1, new CircleTouchDamageInfo(Vector3.zero, 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 3, new CircleTouchDamageInfo(new Vector3(10, 0, 0), 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 5, new CircleTouchDamageInfo(new Vector3(7, 0, 7), 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 7, new CircleTouchDamageInfo(new Vector3(0, 0, 10), 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 9, new CircleTouchDamageInfo(new Vector3(-7, 0, 7), 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 11, new CircleTouchDamageInfo(new Vector3(-10, 0, 0), 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 13, new CircleTouchDamageInfo(new Vector3(-7, 0, -7), 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 15, new CircleTouchDamageInfo(new Vector3(0, 0, -10), 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 17, new CircleTouchDamageInfo(new Vector3(7, 0, -7), 80000, 10f, 10));
                foreach (PlayerController player in players)
                {
                    timeLine.AddDamage(delaySecond + 19, new CircleTouchDamageInfo(player.gameObject, 40000, 2f, 4));
                }
                foreach (PlayerController player in players)
                {
                    timeLine.AddDamage(delaySecond + 21, new CircleTouchDamageInfo(player.gameObject, 40000, 2f, 4));
                }
                foreach (PlayerController player in players)
                {
                    timeLine.AddDamage(delaySecond + 23, new CircleTouchDamageInfo(player.gameObject, 40000, 2f, 4));
                }
                break;
            case 1:
                timeLine.AddDamage(delaySecond + 1, new CircleTouchDamageInfo(Vector3.zero, 80000, 10f, 5));
                timeLine.AddDamage(delaySecond + 4, new RingTouchDamageInfo(Vector3.zero, 80000, 10f, 5.1f, 10));
                timeLine.AddDamage(delaySecond + 7, new RingTouchDamageInfo(Vector3.zero, 80000, 10f, 10.1f, 15));
                timeLine.AddDamage(delaySecond + 10, new RingTouchDamageInfo(Vector3.zero, 80000, 10f, 15.1f, 20));
                timeLine.AddDamage(delaySecond + 14, new CircleTouchDamageInfo(new Vector3(14, 0, 14), 80000, 10f, 20));
                timeLine.AddDamage(delaySecond + 14, new CircleTouchDamageInfo(new Vector3(14, 0, -14), 80000, 10f, 20));
                timeLine.AddDamage(delaySecond + 14, new CircleTouchDamageInfo(new Vector3(-14, 0, 14), 80000, 10f, 20));
                timeLine.AddDamage(delaySecond + 14, new CircleTouchDamageInfo(Vector3.zero, 80000, 10f, 5));
                timeLine.AddDamage(delaySecond + 17, new RingTouchDamageInfo(Vector3.zero, 80000, 10f, 5.1f, 10));
                timeLine.AddDamage(delaySecond + 20, new RingTouchDamageInfo(Vector3.zero, 80000, 10f, 10.1f, 15));
                timeLine.AddDamage(delaySecond + 23, new RingTouchDamageInfo(Vector3.zero, 80000, 10f, 15.1f, 20));
                break;
            case 2:
                timeLine.AddDamage(delaySecond + 1, new CircleTouchDamageInfo(new Vector3(20, 0, 0), 80000, 10f, 20));
                timeLine.AddDamage(delaySecond + 1, new CircleTouchDamageInfo(new Vector3(-20, 0, 0), 80000, 10f, 20));
                foreach (PlayerController player in players)
                {
                    timeLine.AddDamage(delaySecond + 3, new CircleTouchDamageInfo(player.gameObject, 40000, 2f, 4));
                }
                foreach (PlayerController player in players)
                {
                    timeLine.AddDamage(delaySecond + 9, new CircleTouchDamageInfo(player.gameObject, 40000, 2f, 4));
                }
                timeLine.AddDamage(delaySecond + 11, new RingTouchDamageInfo(new Vector3(20, 0, 0), 80000, 10f, 10));
                timeLine.AddDamage(delaySecond + 11, new RingTouchDamageInfo(new Vector3(-20, 0, 0), 80000, 10f, 10));
                foreach (PlayerController player in players)
                {
                    timeLine.AddDamage(delaySecond + 16, new RingTouchDamageInfo(player.gameObject, 40000, 2f, 4, 8));
                }
                break;
        }
    }

    public void CheckPlayerChanged()
    {
        foreach (string name in FNet.Instance.playerNicknames.Keys)
        {
            if (!players.ContainsKey(name))
            {
                PlayerController player = Instantiate(playerPrefab, GenerateRespawnPos(),Quaternion.identity).GetComponent<PlayerController>();
                players.Add(name, player);
                player.Init(name);
                ChatManager.Instance.AddMessage("欢迎玩家 " + name + " 进入房间！", true);
            }
        }
        foreach (var player in players.ToList())
        {
            if (!FNet.Instance.playerNicknames.ContainsKey(player.Key))
            {
                ChatManager.Instance.AddMessage("玩家 " + player.Key + " 退出房间！", true);
                Destroy(player.Value.gameObject);
                players.Remove(player.Key);
            }
        }
    }

    public Vector3 GenerateRespawnPos()
    {
        return new Vector3(0, 0, -15) + Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.up) * Vector3.forward * 2f;
    }
}
