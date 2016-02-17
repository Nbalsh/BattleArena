using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ProgressBar : NetworkBehaviour{
    public PlayerSetup.PlayerEnum player;
    private NetworkIdentity networkIdentity;
    Image image;
    public float timeToFill = 8.0f;

    [SyncVar] private bool syncFillBar = false;

    [SyncVar] private float syncTimeUntilFillAgain = 0.0f;

    void Start()
    {
        
        image = GetComponent<Image>();
        networkIdentity = gameObject.GetComponent<NetworkIdentity>();
        image.fillAmount = 1;
    }

    void Update()
    {
        if (syncFillBar)
        {
            image.fillAmount = Mathf.MoveTowards(image.fillAmount, 1f, Time.deltaTime / timeToFill);
        } else if (syncTimeUntilFillAgain < Time.deltaTime)
        {
            syncFillBar = false;
        }
    }

    [Command]
    public void CmdActivateProgressBar()
    {
        networkIdentity.AssignClientAuthority(connectionToClient);
        if (syncTimeUntilFillAgain < Time.fixedTime)
        {
            syncTimeUntilFillAgain = Time.fixedTime + timeToFill;
            image.fillAmount = 0;
            syncFillBar = true;
        }
        networkIdentity.RemoveClientAuthority(connectionToClient);
    }

    [Client]
    public void ActivateProgressBar()
    {
            CmdActivateProgressBar();
    }
}
