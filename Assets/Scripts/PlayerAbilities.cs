using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour {

    ProgressBar progressBar;

	// Use this for initialization
	void Start () {
        progressBar = GameObject.FindObjectOfType(typeof(ProgressBar)) as ProgressBar;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            progressBar.ActivateProgressBar();
        }
	}
}
