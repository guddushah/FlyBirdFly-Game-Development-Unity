using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomplayer : MonoBehaviour {

    // Use this for initialization
    public GameObject catapault;
    public Vector3 pos;
   // private int i;
	void Start ()
    {
        /*Instantiate(catapault[1], new Vector3(pos.x, pos.y, transform.position.z), Quaternion.identity);
        pos.x = Random.Range(-1.8f, 1.8f);
        pos.y += Random.Range(1.5f, 3.5f);*/
        catPau();     
    }

    // Update is called once per frame
    void Update () {
       
		
	}
    public void catPau()
    {    
       // i = Random.Range(0, 2);
        Instantiate(catapault, new Vector3(pos.x, pos.y, transform.position.z), Quaternion.identity);      
       pos.x = Random.Range(-1.8f, 1.8f);
        pos.y += Random.Range(1.5f, 3.5f);
    }

}
