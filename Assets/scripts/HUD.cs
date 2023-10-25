using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    // Use this for initialization
    public GameObject panel;
    public bool pausePressed;
	void Start () {
		
	}
	
	// Update is called once per frame
	
    public void PlayAgainBtn()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);

    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("catapault");
    }
    public void onquit()
    {
        Application.Quit();
    }

    public void onResume()
    {
       if(Time.timeScale==1)
        {
            Time.timeScale = 0;
        }
        pausePressed = true;
        panel.SetActive(true);
    }


   public void ResumeBAck()
    {
        if(Time.timeScale==0)
        {
            Time.timeScale = 1;
        }
        panel.SetActive(false);
    }

}
