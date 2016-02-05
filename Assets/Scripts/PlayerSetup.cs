using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

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
	}
	
}
