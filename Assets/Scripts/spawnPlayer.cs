using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject spawnSpot;

	// Use this for initialization
	void Start () {

        Instantiate(playerPrefab, spawnSpot.transform.position, spawnSpot.transform.rotation);
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
