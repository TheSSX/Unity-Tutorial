﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetectorControlla : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("mario");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
