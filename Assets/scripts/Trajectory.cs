using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trajectory : MonoBehaviour {

    // Use this for initialization
    private GameObject ball;
    public Rigidbody2D rb2d;
    private GameObject trajectoryDots;
    public Sprite dotSprite;
    public bool changeSpriteAfterStart;
    public float initialDotSize;
    public int numberOfDots;
    public float dotSeperation;
    public float dotShift;
    private Vector3 ballPos;
    private Vector3 ballCursorDrift;
    private Vector2 shotForce;
    private float x1, y1;
    private bool ballIsClicked1 = false;
    private bool ballIsClicked2 = false;
    private GameObject ballClick;
    public float shootingPowerX;
    public float shootingPowerY;
    public bool grabwhileMoving;
    public GameObject[] dots;
    private Vector3 fingerPos;
    private Vector3 ballFingerDiff;
    public GameObject threshold;
    public int score = 0;
    public Text scorePlat;
    public Text scoreFinal;
    public GameObject endPanel;
    public bool gameOver;
    Randomplayer random;
    public GameObject obJ;
    Cameraupdate cam;
    public GameObject checkObj;
    nestNew newnest;
    nestNew2 newnest2;
    private Animator anim;
    //timerGUI
    private float timer = 10.0f;
    private bool isGui;

    void Start () {
        ball = gameObject;
        isGui = true;
        anim = GetComponent<Animator>();
        threshold = GameObject.Find("threShold");
        newnest = FindObjectOfType<nestNew>();
        newnest2 = FindObjectOfType<nestNew2>();
        checkObj = GameObject.Find("playerGen");
        obJ = GameObject.Find("destroy");
        random = FindObjectOfType<Randomplayer>();
        cam = FindObjectOfType<Cameraupdate>();
        ballClick = GameObject.Find("ballclickarea");
        trajectoryDots = GameObject.Find("Trajectory");
        rb2d = GetComponent<Rigidbody2D>();
        trajectoryDots.transform.localScale = new Vector3(initialDotSize, initialDotSize,trajectoryDots.transform.localScale.z);
        for (int i=0;i<=22;i++)
        {
            dots[i] = GameObject.Find("dot (" + i + ")");
            if (dotSprite != null)
            {
                dots[i].GetComponent<SpriteRenderer>().sprite = dotSprite;
            }
        }
    /*  for(int i=numberOfDots;i<=22;i++)
        {
            GameObject.Find("dot (" + i + ")").SetActive(false);
        }*/
        trajectoryDots.SetActive(false);
	}

    // Update is called once per frame
    void Update() {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && ballIsClicked2 == false)
        {
            if (hit.collider.gameObject.name == ballClick.gameObject.name)
            {
                ballIsClicked1 = true;
            }
            else
                ballIsClicked1 = false;
        }
        else
            ballIsClicked1 = false;

        if (ballIsClicked2 == true)
        {
            ballIsClicked1 = true;
        }
        if (((rb2d.velocity.x * rb2d.velocity.x) + (rb2d.velocity.y * rb2d.velocity.y)) <= 0.005f)
        {
            rb2d.velocity = new Vector2(0f, 0f);
        }
        else
        { trajectoryDots.SetActive(false); }


        ballPos = ball.transform.position;
      
        if ((Input.GetKey(KeyCode.Mouse0) && ballIsClicked1 == true) && ((rb2d.velocity.x == 0f && rb2d.velocity.y == 0f) || grabwhileMoving == true))
        {
            //  pop();
           //anim.SetBool("fly1", true);
            ballIsClicked2 = true;
            fingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            fingerPos.z = 0;
           if (grabwhileMoving == true && rb2d.velocity != new Vector2(0, 0))
            {
                grabwhileMoving = false;
              //  rb2d.velocity = new Vector2(0f, 0f);
               // rb2d.isKinematic = true;
            }
            
            ballFingerDiff = ballPos - fingerPos;
            shotForce = new Vector2(ballFingerDiff.x * shootingPowerX, ballFingerDiff.y * shootingPowerY);
            if ((Mathf.Sqrt((ballFingerDiff.x * ballFingerDiff.x) + (ballFingerDiff.y * ballFingerDiff.y)) > 0.4f))
            {
                trajectoryDots.SetActive(true);
            }
            else
            {
                trajectoryDots.SetActive(false);
                if (rb2d.isKinematic == true)
                {
                    rb2d.isKinematic = false;
                }
            }
            for (int i = 0; i <= numberOfDots; i++)
            {
                x1 = ballPos.x + shotForce.x * Time.fixedDeltaTime * (dotSeperation * i + dotShift);
                y1 = ballPos.y + shotForce.y * Time.fixedDeltaTime * (dotSeperation * i + dotShift) - (-Physics2D.gravity.y / 4f) * Time.fixedDeltaTime * (dotSeperation * i + dotShift) * (dotSeperation * i + dotShift);
                dots[i].transform.position = new Vector3(x1, y1, dots[i].transform.position.z);
              

            }
            anim.SetBool("fly1", true);

        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ballIsClicked2 = false;
            if (trajectoryDots.activeInHierarchy)
            {
                trajectoryDots.SetActive(false);
                rb2d.velocity = new Vector2(shotForce.x/5, shotForce.y/5);
                if (rb2d.isKinematic == true)
                {
                    rb2d.isKinematic = false;
                }
            }
        }      
     }
   /* public void pop()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            endGame();
        }
    }
    private void OnGUI()
    {
        if (isGui)
        {
            GUI.Box(new Rect(10, 10, 50, 30), "" + timer.ToString("0"));
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "scorePlat")
        {
            scorePlat.text = "Score:" + score.ToString();
            scoreFinal.text = "SCORE : " + score.ToString();
            score++;
            Destroy(collision.gameObject);

        }
       if (collision.gameObject.tag == "nest1")
        {
            anim.SetBool("blink1", true);
            anim.SetBool("fly1", false);
            newnest2.catPau();
            newnest.catPau();
            newnest2.catPau();
           // newnest.catPau();
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "nest2")
        {
            anim.SetBool("blink1", true);
            anim.SetBool("fly1", false);
            newnest.catPau();
            newnest2.catPau();
            Destroy(collision.gameObject);

        }
    }
  /* IEnumerator pic()
    {
        yield return new WaitForSeconds(-0.1f);
    }*/
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            endGame();
        }
        if (collision.gameObject.tag == "hello")
        {
           anim.SetBool("fly1", false);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="hello")
        {
            anim.SetBool("blink1",false);
            // anim.SetBool("fly1", false);

        }
    }

    public void endGame()
    {
       // isGui = false;
        cam.followSpeed = 0;
        gameOver = true;
        endPanel.SetActive(true);
    }
   
}
