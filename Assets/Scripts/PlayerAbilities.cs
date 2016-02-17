using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAbilities : MonoBehaviour {

    ProgressBar progressBar;
    PlayerSetup.PlayerEnum player;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            progressBar.ActivateProgressBar();
        }
	}

    public void PlayerAbilitiesSetUp(PlayerSetup playerSetup)
    {
        ProgressBar[] progressBars = GameObject.FindObjectsOfType<ProgressBar>();
        player = playerSetup.playerNum;
        for (var i = 0; i < 4; i++)
        {
            if (progressBars[i].player == player)
            {
                progressBar = progressBars[i];
            }
        }
    }
}
