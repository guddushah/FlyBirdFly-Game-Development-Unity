﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < GameObject.Find("threShold").transform.position.y)
        {
            Destroy(GameObject.Find("branch-2(Clone)"));
        }
    }
}