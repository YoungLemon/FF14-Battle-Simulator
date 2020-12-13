using FFSimulator.client.views;
using limax.endpoint;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace FFSimulator_client
{

    enum ConnectionState
    {
        OFFLINE,
        MAIN,
        PLAYING
    }

    class FNet
    {

        private const int providerId = 100;

        public static readonly FNet Instance = new FNet();
        public static int ViewTIndex { get; set; } = -1;
        public string nickname { get; private set; } = "Default";

        public ConnectionState connectionState = ConnectionState.OFFLINE;

        public Dictionary<string, long> playerNicknames = new Dictionary<string, long>();

        public void Login(string nickname, string serverIP)
        {
            Instance.nickname = nickname;
            Endpoint.openEngine();
            EndpointConfig config = Endpoint.createEndpointConfigBuilder(
                    serverIP, 30000, LoginConfig.plainLogin(nickname, "123456", "test"))
                .staticViewClasses(ViewManager.createInstance(providerId))
                .build();
            Endpoint.start(config, new MyListener());
        }

        public void Quit()
        {
            ViewS.getInstance().LeaveRoom(0);
            object obj = new object();
            Action done = () => { lock (obj) { Monitor.Pulse(obj); } };
            lock (obj)
            {
                Endpoint.closeEngine(done);
                Monitor.Wait(obj);
            }
        }

        /// <summary>
        /// 有玩家登录时更新玩家列表
        /// </summary>
        public void UpdatePlayers()
        {
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewT.getInstance(ViewTIndex).visitNickname(e =>
                    {
                        playerNicknames.Clear();
                        foreach (var pair in e)
                        {
                            // pair.Key为玩家sessionID
                            playerNicknames.Add(pair.Value.nickname, pair.Key);
                        }
                        Debug.Log("Player Num: " + playerNicknames.Count);
                    });
                }
                catch (Exception) { Debug.Log("Error in FNet.UpdatePlayers"); }
            }
        }

        /// <summary>
        /// 更新游戏状态
        /// </summary>
        public void UpdateState()
        {
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewT.getInstance(ViewTIndex).visitIsPlaying(e =>
                    {
                        if (e) connectionState = ConnectionState.PLAYING;
                        else connectionState = ConnectionState.MAIN;
                    });
                }
                catch (Exception) { Debug.Log("Error in FNet.UpdateState. Now UpdatePlayers..."); }
            }
        }

        /// <summary>
        /// 开始执行时间轴
        /// </summary>
        public void StartPlaying()
        {
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewT.getInstance(ViewTIndex).StartPlaying();
                }
                catch (Exception) 
                { 
                    Debug.Log("Error in FNet.StartPlaying. Now UpdatePlayers...");
                    UpdatePlayers();
                }
            }
        }

        /// <summary>
        /// 结束时间轴
        /// </summary>
        public void EndPlaying()
        {
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewT.getInstance(ViewTIndex).EndPlaying();
                }
                catch (Exception) 
                { 
                    Debug.Log("Error in FNet.EndPlaying. Now UpdatePlayers...");
                    UpdatePlayers();
                }
            }
        }

        /// <summary>
        /// 登录后将聊天室注册到服务器
        /// </summary>
        public void RegisterChatroom()
        {
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewT.getInstance(ViewTIndex).registerListener("lastMessage", e =>
                    {
                        if (e.type == ViewChangedType.REPLACE || e.type == ViewChangedType.TOUCH)
                            ChatManager.Instance.messageServer = e.value.ToString();
                    });
                }
                catch (Exception)
                {
                    Debug.Log("Error in FNet.RegisterChatroom");
                }
            }
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewT.getInstance(ViewTIndex).SendMessage(message);
                }
                catch (Exception)
                {
                    Debug.Log("Error in FNet.SendMessage. Now UpdatePlayers...");
                    UpdatePlayers();
                }
            }
        }

        /// <summary>
        /// 获取指定角色Hp
        /// </summary>
        /// <param name="nickname"></param>
        public int GetHp(string nickname)
        {
            int hp = 0;
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewT.getInstance(ViewTIndex).visitHp(e =>
                    {
                        hp = e[playerNicknames[nickname]].hp;
                    });
                }
                catch (Exception) 
                { 
                    Debug.Log("Error in FNet.GetHp. Now UpdatePlayers...");
                    UpdatePlayers();
                }
            }
            return hp;
        }

        /// <summary>
        /// 将自己的血量同步到服务器
        /// </summary>
        /// <param name="curHp"></param>
        public void SetHp(int curHp)
        {
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewS.getInstance().SetHp(curHp);
                }
                catch (Exception) 
                { 
                    Debug.Log("Error in FNet.SetHp. Now UpdatePlayers...");
                    UpdatePlayers();
                }
            }
        }

        /// <summary>
        /// 获取指定玩家的位置
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public Vector3 GetPosition(string nickname)
        {
            Vector3 pos = Vector3.zero;
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewT.getInstance(ViewTIndex).visitPosition(e =>
                    {
                        var positionServer = e[playerNicknames[nickname]].position;
                        pos = new Vector3(positionServer.x, 0.3f, positionServer.y);
                    });
                }
                catch (Exception) 
                { 
                    Debug.Log("Error in FNet.GetPosition. Now UpdatePlayers...");
                    UpdatePlayers();
                }
            }
            return pos;
        }

        /// <summary>
        /// 将自己的位置同步到服务器
        /// </summary>
        /// <param name="curPos"></param>
        public void SetPosition(Vector3 curPos)
        {
            if (connectionState != ConnectionState.OFFLINE)
            {
                //这里记得检查抛出异常，不然玩家人数减少后会导致连接中断
                try
                {
                    ViewS.getInstance().SetPosition(curPos.x, curPos.z);
                }
                catch (Exception) 
                { 
                    Debug.Log("Error in FNet.SetPosition. Now UpdatePlayers...");
                    UpdatePlayers();
                }
            }
        }
    }
}
