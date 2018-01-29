using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour {

    public GameObject sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10;

    public GameObject scoreBall1;
    public GameObject scoreBall2;
    public GameObject scoreBall3;
    public GameObject scoreBall4;
    public GameObject scoreBall5;


    BallMovement ballMov;


    public bool check1, check2, check3, check4, check5;
    public bool check1b, check2b, check3b, check4b, check5b;
    public float dist1, dist2, dist3, dist4, dist5;
    public float dist1b, dist2b, dist3b, dist4b, dist5b;
    bool checkScore1, checkScore2;
    float score1, score2;

    PlayerController playerController;
    EventHandler eventHandler;
    GameObject player1, player2;


    float timer;
    // Use this for initialization
    void Start() {
        ballMov = FindObjectOfType<BallMovement>();
        playerController = GetComponent<PlayerController>();
        eventHandler = FindObjectOfType<EventHandler>();

        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

        sphere1 = GameObject.Find("Sphere 1");
        sphere2 = GameObject.Find("Sphere 2");
        sphere3 = GameObject.Find("Sphere 3");
        sphere4 = GameObject.Find("Sphere 4");
        sphere5 = GameObject.Find("Sphere 5");
        sphere6 = GameObject.Find("Sphere 1");
        sphere7 = GameObject.Find("Sphere 2");
        sphere8 = GameObject.Find("Sphere 3");
        sphere9 = GameObject.Find("Sphere 4");
        sphere10 = GameObject.Find("Sphere 5");

        scoreBall1 = GameObject.Find("ScoreBall 1");
        scoreBall2 = GameObject.Find("ScoreBall 2");
        scoreBall3 = GameObject.Find("ScoreBall 3");
        scoreBall4 = GameObject.Find("ScoreBall 4");
        scoreBall5 = GameObject.Find("ScoreBall 5");


        if (ballMov.sphereInstantiation.name == "Sphere 1" && !check1 ||
            ballMov.sphereInstantiation.name == "Sphere 6" && !check1)
        {
            if (ballMov.sphereInstantiation.name == "Sphere 1")
                dist1 = Vector3.Distance(sphere1.transform.position, scoreBall1.transform.position);
            else
                dist1 = Vector3.Distance(sphere6.transform.position, scoreBall1.transform.position);
            Debug.Log("Dist 1 : " + dist1);
            check1 = true;
        }
        if (ballMov.sphereInstantiation.name == "Sphere 2" && !check2 ||
            ballMov.sphereInstantiation.name == "Sphere 7" && !check2)
        {
            if (ballMov.sphereInstantiation.name == "Sphere 2")
                dist2 = Vector3.Distance(sphere2.transform.position, scoreBall2.transform.position);
            else
                dist2 = Vector3.Distance(sphere7.transform.position, scoreBall1.transform.position);
            Debug.Log("Dist 2 : " + dist2);
            check2 = true;
        }
        if (ballMov.sphereInstantiation.name == "Sphere 3" && !check3 ||
            ballMov.sphereInstantiation.name == "Sphere 8" && !check3)
        {
            if (ballMov.sphereInstantiation.name == "Sphere 3")
                dist3 = Vector3.Distance(sphere3.transform.position, scoreBall3.transform.position);
            else
                dist3 = Vector3.Distance(sphere8.transform.position, scoreBall1.transform.position);
            Debug.Log("Dist 3 : " + dist3);
            check3 = true;
        }
        if (ballMov.sphereInstantiation.name == "Sphere 4" && !check4 ||
            ballMov.sphereInstantiation.name == "Sphere 9" && !check4)
        {
            if (ballMov.sphereInstantiation.name == "Sphere 4")
                dist4 = Vector3.Distance(sphere4.transform.position, scoreBall4.transform.position);
            else
                dist4 = Vector3.Distance(sphere9.transform.position, scoreBall1.transform.position);
            Debug.Log("Dist 4 : " + dist4);
            check4 = true;
        }
        if (ballMov.sphereInstantiation.name == "Sphere 5" && !check5 ||
            ballMov.sphereInstantiation.name == "Sphere 10" && !check5)
        {
            if (ballMov.sphereInstantiation.name == "Sphere 5")
                dist5 = Vector3.Distance(sphere5.transform.position, scoreBall5.transform.position);
            else
                dist5 = Vector3.Distance(sphere10.transform.position, scoreBall1.transform.position);
            Debug.Log("Dist 5 : " + dist5);
            check5 = true;
        }

        if (dist5 != 0 && !checkScore1 && score1 <= 0)
        {
            score1 = dist1 + dist2 + dist3 + dist4 + dist5;
            Debug.Log("SCORE 1 : " + score1);
            checkScore1 = true;
        }




        if (ballMov.sphereInstantiation.name == "Sphere 1" && check1b)
        {
            dist1b = Vector3.Distance(sphere1.transform.position, scoreBall1.transform.position);
            Debug.Log("Dist 1b : " + dist1b);
        }
        if (ballMov.sphereInstantiation.name == "Sphere 2" && check2b)
        {
            dist2b = Vector3.Distance(sphere2.transform.position, scoreBall2.transform.position);
            Debug.Log("Dist 2b : " + dist2b);
        }
        if (ballMov.sphereInstantiation.name == "Sphere 3" && check3b)
        {
            dist3b = Vector3.Distance(sphere3.transform.position, scoreBall3.transform.position);
            Debug.Log("Dist 3b : " + dist3b);
        }
        if (ballMov.sphereInstantiation.name == "Sphere 4" && check4b)
        {
            dist4b = Vector3.Distance(sphere4.transform.position, scoreBall4.transform.position);
            Debug.Log("Dist 4b : " + dist4b);
        }
        if (ballMov.sphereInstantiation.name == "Sphere 5" && check5b)
        {
            dist5b = Vector3.Distance(sphere5.transform.position, scoreBall5.transform.position);
            Debug.Log("Dist 5b : " + dist5b);
        }

        if (dist5b != 0 && !checkScore2 && score2 <= 0)
        {
            score2 = dist1b + dist2b + dist3b + dist4b + dist5b;
            Debug.Log("SCORE 2 : " + score2);
            checkScore2 = true;
            timer = 0f;
        }

        if (checkScore1 && checkScore2)
        {
        }
    }
    /*
    IEnumerator Attacks ()
    {
        yield return new WaitForSeconds(0.75f);
        eventHandler.MainCam();
        if (dist1 < dist1b)
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player1.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player1.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player2.GetComponent<Animator>().SetBool("isHit", true);
        }
        else
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player2.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player2.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player1.GetComponent<Animator>().SetBool("isHit", true);
        }
        yield return new WaitForSeconds(0.75f);
        player1.GetComponent<Animator>().SetBool("isHit", false);
        player1.GetComponent<Animator>().SetBool("isKicking", false);
        player1.GetComponent<Animator>().SetBool("isPunching", false);
        player2.GetComponent<Animator>().SetBool("isHit", false);
        player2.GetComponent<Animator>().SetBool("isKicking", false);
        player2.GetComponent<Animator>().SetBool("isPunching", false);
        if (dist2 < dist2b)
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player1.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player1.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player2.GetComponent<Animator>().SetBool("isHit", true);
        }
        else
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player2.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player2.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player1.GetComponent<Animator>().SetBool("isHit", true);
        }
        yield return new WaitForSeconds(0.75f);
        player1.GetComponent<Animator>().SetBool("isHit", false);
        player1.GetComponent<Animator>().SetBool("isKicking", false);
        player1.GetComponent<Animator>().SetBool("isPunching", false);
        player2.GetComponent<Animator>().SetBool("isHit", false);
        player2.GetComponent<Animator>().SetBool("isKicking", false);
        player2.GetComponent<Animator>().SetBool("isPunching", false);

        if (dist3 < dist3b)
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player1.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player1.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player2.GetComponent<Animator>().SetBool("isHit", true);
        }
        else
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player2.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player2.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player1.GetComponent<Animator>().SetBool("isHit", true);
        }
        yield return new WaitForSeconds(0.75f);
        player1.GetComponent<Animator>().SetBool("isHit", false);
        player1.GetComponent<Animator>().SetBool("isKicking", false);
        player1.GetComponent<Animator>().SetBool("isPunching", false);
        player2.GetComponent<Animator>().SetBool("isHit", false);
        player2.GetComponent<Animator>().SetBool("isKicking", false);
        player2.GetComponent<Animator>().SetBool("isPunching", false);

        if (dist4 < dist4b)
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player1.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player1.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player2.GetComponent<Animator>().SetBool("isHit", true);

        }
        else
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player2.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player2.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player1.GetComponent<Animator>().SetBool("isHit", true);
        }
        yield return new WaitForSeconds(0.75f);
        player1.GetComponent<Animator>().SetBool("isHit", false);
        player1.GetComponent<Animator>().SetBool("isKicking", false);
        player1.GetComponent<Animator>().SetBool("isPunching", false);
        player2.GetComponent<Animator>().SetBool("isHit", false);
        player2.GetComponent<Animator>().SetBool("isKicking", false);
        player2.GetComponent<Animator>().SetBool("isPunching", false);

        if (dist5 < dist5b)
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player1.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player1.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player2.GetComponent<Animator>().SetBool("isHit", true);
        }
        else
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                player2.GetComponent<Animator>().SetBool("isPunching", true);
            }
            else
            {
                player2.GetComponent<Animator>().SetBool("isKicking", true);
            }

            player1.GetComponent<Animator>().SetBool("isHit", true);
        }
    }

    */

}
