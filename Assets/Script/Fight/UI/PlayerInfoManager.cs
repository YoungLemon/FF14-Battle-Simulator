using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public static PlayerInfoManager Instance = null;

    public GameObject playerInfoPrefab;
    public Dictionary<string, PlayerInfoUI> playerInfos = new Dictionary<string, PlayerInfoUI>();

    private void Awake()
    {
        playerInfos.Clear();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayerInfo(string name)
    {
        PlayerInfoUI playerInfo = Instantiate(playerInfoPrefab, Vector3.zero, Quaternion.identity).GetComponent<PlayerInfoUI>();
        playerInfo.player = FightManager.Instance.players[name];
        playerInfo.transform.SetParent(transform, false);
        playerInfos.Add(name, playerInfo);
    }

    public void RemovePlayerInfo(string name)
    {
        if (playerInfos.ContainsKey(name) && playerInfos[name] != null)
        {
            Destroy(playerInfos[name].gameObject);
            playerInfos.Remove(name);
        }
    }
}
