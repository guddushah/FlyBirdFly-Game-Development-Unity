using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour {

    // Use this for initialization
    public Text highScorePlat;
    private int highScore;
    Trajectory traject;
	void Start () {
        traject = FindObjectOfType<Trajectory>();
        if(PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(traject.score>highScore)
        {
            highScore = traject.score-1;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        highScorePlat.text = "HIGHSCORE : " + highScore;

    }
}
