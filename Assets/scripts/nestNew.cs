﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nestNew : MonoBehaviour {

    // Use this for initialization
    public GameObject[] nestN;
    public Vector3 pos;
    Cameraupdate cam;
    public GameObject obj;
     private int i;
	void Start () {
  
        Instantiate(nestN[0], new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        pos.y += Random.Range(3.5f,5.2f);
    }

    // Update is called once per frame
    private void Update()
    {

    }
    public void catPau()
    {
        
         i = Random.Range(0, 2);
        Instantiate(nestN[i], new Vector3(pos.x, pos.y, 0f), Quaternion.identity);
        pos.x = Random.Range(1.1f, 1.3f);
        pos.y += Random.Range(3.5f,5.2f);       
    }
  
}
