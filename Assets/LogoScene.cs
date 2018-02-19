using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(startGame(20));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator startGame(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Application.LoadLevel("Main Menu");
    }
}
