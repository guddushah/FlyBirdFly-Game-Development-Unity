using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeMov : MonoBehaviour {

    // Use this for initialization
    public float speed;
    Rigidbody2D rb2d;
    Trajectory traject;

    //speed booster
    public float speedMultiplier;
    public float speedIncreasedMilestone;
    private float speedMilestoneCount;
    
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        traject = FindObjectOfType<Trajectory>();
        speedMilestoneCount = speedIncreasedMilestone;
	}

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreasedMilestone;
            speedIncreasedMilestone = speedIncreasedMilestone * speedMultiplier;
            speed = speed * speedMultiplier;
        }

     
    }
}
