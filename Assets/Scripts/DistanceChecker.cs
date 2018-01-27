using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour {

    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject sphere3;
    public GameObject sphere4;
    public GameObject sphere5;

    public GameObject scoreBall1;
    public GameObject scoreBall2;
    public GameObject scoreBall3;
    public GameObject scoreBall4;
    public GameObject scoreBall5;


    BallMovement ballMov;


    public bool check1, check2, check3, check4, check5;
    public bool check1b, check2b, check3b, check4b, check5b;
    float dist1, dist2, dist3, dist4, dist5;
    float dist1b, dist2b, dist3b, dist4b, dist5b;
    bool checkScore1, checkScore2;
    float score1, score2;

    PlayerController playerController;

    GameObject player1, player2;

    // Use this for initialization
    void Start () {
        ballMov = FindObjectOfType<BallMovement>();
        playerController = GetComponent<PlayerController>();

        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }
	
	// Update is called once per frame
	void Update () {
        sphere1 = GameObject.Find("Sphere 1");
        sphere2 = GameObject.Find("Sphere 2");
        sphere3 = GameObject.Find("Sphere 3");
        sphere4 = GameObject.Find("Sphere 4");
        sphere5 = GameObject.Find("Sphere 5");

        scoreBall1 = GameObject.Find("ScoreBall 1");
        scoreBall2 = GameObject.Find("ScoreBall 2");
        scoreBall3 = GameObject.Find("ScoreBall 3");
        scoreBall4 = GameObject.Find("ScoreBall 4");
        scoreBall5 = GameObject.Find("ScoreBall 5");


        if (ballMov.instantiation.name == "Sphere 1" && !check1)
        {
            dist1 = Vector3.Distance(sphere1.transform.position, scoreBall1.transform.position);
            Debug.Log("Dist 1 : " + dist1);
            check1 = true;
        }
        if (ballMov.instantiation.name == "Sphere 2" && !check2)
        {
            dist2 = Vector3.Distance(sphere2.transform.position, scoreBall2.transform.position);
            Debug.Log("Dist 2 : " + dist2);
            check2 = true;
        }
        if (ballMov.instantiation.name == "Sphere 3" && !check3)
        {
            dist3 = Vector3.Distance(sphere3.transform.position, scoreBall3.transform.position);
            Debug.Log("Dist 3 : " + dist3);
            check3 = true;
        }



        if (ballMov.instantiation.name == "Sphere 4" && !check4)
        {
            dist4 = Vector3.Distance(sphere4.transform.position, scoreBall4.transform.position);
            Debug.Log("Dist 4 : " + dist4);
            check4 = true;
        }
        if (ballMov.instantiation.name == "Sphere 5" && !check5)
        {
            dist5 = Vector3.Distance(sphere5.transform.position, scoreBall5.transform.position);
            Debug.Log("Dist 5 : " + dist5);
            check5 = true;
        }

        if (dist5 != 0 && !checkScore1 && score1 <= 0)
        {
            score1 = dist1 + dist2 + dist3 + dist4 + dist5;
            Debug.Log("SCORE 1 : " + score1);
            checkScore1 = true;
        }




        if (ballMov.instantiation.name == "Sphere 1" && check1b)
        {
            dist1b = Vector3.Distance(sphere1.transform.position, scoreBall1.transform.position);
            Debug.Log("Dist 1b : " + dist1b);
        }
        if (ballMov.instantiation.name == "Sphere 2" && check2b)
        {
            dist2b = Vector3.Distance(sphere2.transform.position, scoreBall2.transform.position);
            Debug.Log("Dist 2b : " + dist2b);
        }
        if (ballMov.instantiation.name == "Sphere 3" && check3b)
        {
            dist3b = Vector3.Distance(sphere3.transform.position, scoreBall3.transform.position);
            Debug.Log("Dist 3b : " + dist3b);
        }
        if (ballMov.instantiation.name == "Sphere 4" && check4b)
        {
            dist4b = Vector3.Distance(sphere4.transform.position, scoreBall4.transform.position);
            Debug.Log("Dist 4b : " + dist4b);
        }
        if (ballMov.instantiation.name == "Sphere 5" && check5b)
        {
            dist5b = Vector3.Distance(sphere5.transform.position, scoreBall5.transform.position);
            Debug.Log("Dist 5b : " + dist5b);
        }

        if (dist5b != 0 && !checkScore2 && score2 <= 0)
        {
            score2 = dist1b + dist2b + dist3b + dist4b + dist5b;
            Debug.Log("SCORE 2 : " + score2);
            checkScore2 = true;
        }

        if (checkScore1 && checkScore2)
        {
            string winner = Mathf.Min(score1, score2).ToString();
            if (winner == score1.ToString())
            {
                Debug.Log("The winner is player 1 with a score of: " + winner);
                player1.GetComponent<Animator>().SetBool("isPunching", true);
                player2.GetComponent<Animator>().SetBool("isHit", true);
            } else if (winner == score2.ToString())
            {
                Debug.Log("The winner is player 2 with a score of: " + winner);
                player2.GetComponent<Animator>().SetBool("isPunching", true);
                player1.GetComponent<Animator>().SetBool("isHit", true);

            }
            
        }

    }
}
