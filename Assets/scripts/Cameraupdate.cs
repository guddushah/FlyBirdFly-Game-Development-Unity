using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraupdate : MonoBehaviour {

    // Use this for initialization

    public Transform ball;
    private Vector3 offset;
    float xPos;
    public float followSpeed;
    public float yValue;
    //public GameObject obg;
   

	void Start () {
        offset = transform.position - ball.transform.position;
        xPos = transform.position.x;
		
	}

    // Update is called once per frame
    public void LateUpdate()
    {
        Vector3 newPos = offset + ball.transform.position;
        newPos.x = xPos;
        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);

        if (transform.position.y < yValue)
           {
              
               transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
           }

    
    }
}
