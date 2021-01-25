using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerPlayerManager : MonoBehaviour
{
    [HideInInspector] public GameObject[] players;

    private void Start()
    {
        players = new GameObject[8];
        players[0] = GameObject.Find("MT");
        players[1] = GameObject.Find("ST");
        players[2] = GameObject.Find("H1");
        players[3] = GameObject.Find("H2");
        players[4] = GameObject.Find("D1");
        players[5] = GameObject.Find("D2");
        players[6] = GameObject.Find("D3");
        players[7] = GameObject.Find("D4");
    }
}
