using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nestNew2 : MonoBehaviour {

    // Use this for initialization
    public GameObject[] nestN;
    public Vector3 pos;
    private int i;
    public GameObject obj;
    nestNew nest1;
    void Start () {
        nest1 = FindObjectOfType<nestNew>();
	}
	
	// Update is called once per frame
	void Update () {
      
    }
    public void catPau()
    {

        i = Random.Range(0, 2);
        Instantiate(nestN[i], new Vector3(pos.x, pos.y, 0f), Quaternion.identity);
        pos.x = Random.Range(-1.1f, -0.9f);
        pos.y += Random.Range(3.5f,5.2f);

    }
}
