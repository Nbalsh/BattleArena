using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    private int numOfPlayers = 0;
    PlayerSetup[] players = new PlayerSetup[4];

    void Start()
    {
    }

    public int NewPlayerSetUpNumber(PlayerSetup player)
    {
        for(var i = 0; i < 4; i++)
        {
            if(players[i] == null)
            {
                numOfPlayers++;
                players[i] = player;
                return i;
            }
            if(players[i] != null && players[i].playerNum == PlayerSetup.PlayerEnum.empty)
            {
                numOfPlayers++;
                players[i] = player;
                return i;
            }
        }
        return -1;
    }

}
