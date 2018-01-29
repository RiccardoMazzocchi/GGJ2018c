using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    public Camera mainCam;
    public Camera battleCamP1;
    public Camera battleCamP2;

    public GameObject sineGame;
    float battleTimer;


    BallMovement ballMov;
    public GameObject attackHandler;
    bool hasInstantiated;
    bool p1c, p2c, round2, round3, round2b;
    public GameObject fightImage, ball, background, colliderHolder;
    MicTest micTest;
    DistanceChecker distCheck;
    GameObject attackHandlerInstantiation;
    private void Awake()
    {
        //sineGame = GameObject.Find("Sine Mini Game");
        //sineGame.gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        distCheck = FindObjectOfType<DistanceChecker>();
        micTest = FindObjectOfType<MicTest>();
        ballMov = FindObjectOfType<BallMovement>();

        

        MainCam();

        sineGame = GameObject.Find("Sine Mini Game");
        
        sineGame.gameObject.SetActive(false);
        StartCoroutine("FightImage");
        StartCoroutine("StartSineGame");
        round2 = false;
        round3 = false;
    }
	
	// Update is called once per frame
	void Update () {
        battleTimer += Time.deltaTime;

        if (battleTimer >= 10.5f)
        {
            if (!p2c)
            {
                P2Cam();
                p2c = true;
            }
        }
        if (battleTimer >= 20f)
        {
            if (!hasInstantiated)
            {
                
                attackHandlerInstantiation = Instantiate(attackHandler, transform.position, Quaternion.identity);
                ResetDistBools();
                hasInstantiated = true;
            }
        }

        if (battleTimer >= 38f && !round2)
        {

            
            
            ball.transform.position = ball.GetComponent<BallMovement>().initialPos;
            ball.SetActive(true);
            colliderHolder.SetActive(true);
            background.SetActive(true);
            P1Cam();
            ball.GetComponent<BallMovement>().timesRespawned = 1;
            round2 = true;
        }
        if (battleTimer >= 45 && !round2b)
        {
            P2Cam();
            round2b = true;
        }

        if (battleTimer >= 55f && !round3)
        {
           
            Debug.Log("ATTACK TIMER");
            attackHandlerInstantiation.GetComponent<AttackScript>().timer = 0f;
            attackHandlerInstantiation.GetComponent<AttackScript>().attack1 = false;
                attackHandlerInstantiation.GetComponent<AttackScript>().attack2 = false;
                attackHandlerInstantiation.GetComponent<AttackScript>().attack3 = false;
                attackHandlerInstantiation.GetComponent<AttackScript>().attack4 = false;
                attackHandlerInstantiation.GetComponent<AttackScript>().attack5 = false;
            round3 = true;

        }
    }

    public void ResetDistBools()
    {
        distCheck.check1 = false;
        distCheck.check2 = false;
        distCheck.check3 = false;
        distCheck.check4 = false;
        distCheck.check5 = false;
        distCheck.check1b = false;
        distCheck.check2b = false;
        distCheck.check3b = false;
        distCheck.check4b = false;
        distCheck.check5b = false;
    }

    public void MainCam()
    {
        mainCam.enabled = true;
        battleCamP1.enabled = false;
        battleCamP2.enabled = false;
    }
    public void P1Cam()
    {
        mainCam.enabled = false;
        battleCamP1.enabled = true;
        battleCamP2.enabled = false;
    }
    public void P2Cam()
    {
        mainCam.enabled = false;
        battleCamP1.enabled = false;
        battleCamP2.enabled = true;
    }


    IEnumerator StartSineGame()
    {
        yield return new WaitForSeconds(4f);
        sineGame.gameObject.SetActive(true);
        P1Cam();
    }

    IEnumerator FightImage()
    {
        yield return new WaitForSeconds(1.75f);
        Instantiate(fightImage, transform.position, Quaternion.identity);
    }
    
}
