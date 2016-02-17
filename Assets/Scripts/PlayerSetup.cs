using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {
    GameManager gameManager;
    public enum PlayerEnum { Player1, Player2, Player3, Player4, empty };
    public PlayerEnum playerNum = PlayerEnum.empty;
    [SerializeField]
    Behaviour[] componentsToDisable;
	void Start () {
        if (!isLocalPlayer)
        {
            foreach(Behaviour b in componentsToDisable)
            {
                b.enabled = false;
            }
        }

        gameManager = GameObject.FindObjectOfType<GameManager>();
        var playerNum = gameManager.NewPlayerSetUpNumber(this);
        SetPlayerEnum(playerNum);
        gameObject.GetComponent<PlayerAbilities>().PlayerAbilitiesSetUp(this);
	}

    void SetPlayerEnum(int num)
    {
        if(num == 0)
        {
            playerNum = PlayerEnum.Player1;
        } else if (num == 1)
        {
            playerNum = PlayerEnum.Player2;
        }
        else if (num == 2)
        {
            playerNum = PlayerEnum.Player3;
        }
        else if (num == 3)
        {
            playerNum = PlayerEnum.Player4;
        } else
        {
            playerNum = PlayerEnum.empty;
        }
    }
	
}
