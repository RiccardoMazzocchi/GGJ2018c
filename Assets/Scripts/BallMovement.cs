using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Transform target;
    public float speed;

    public Vector3 initialPos;

    public GameObject spherePrefab;
    public GameObject sphereInstantiation;

    int n = 0;

    DistanceChecker distCheck;

    public GameObject sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10;
    public GameObject scoreBall1, scoreBall2, scoreBall3, scoreBall4, scoreBall5;

    float dist1, dist2, dist3, dist4, dist5;

    GridBalls gridBalls;
    EventHandler eventHandler;

    public GameObject colliderHolder;
    public GameObject sineBoard;

    bool respawned;

    float battleTimer;
    public int timesRespawned = 2;

    PingAudio pingAudio;

    GameObject sineGame;

    public GameObject check, cross;


    //mic movement

    // Use this for initialization
    void Start () {
        //mic movement stuff


        sineGame = GameObject.Find("Sine Game Board");
        pingAudio = FindObjectOfType<PingAudio>();
        distCheck = FindObjectOfType<DistanceChecker>();
        gridBalls = FindObjectOfType<GridBalls>();
        eventHandler = FindObjectOfType<EventHandler>();

        initialPos = transform.position;

        FindBalls();
    }
	
	// Update is called once per frame
	void Update () {
        FindBalls();

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        float distanceToEnd = Vector3.Distance(transform.position, target.transform.position);

    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GridColumn")
        {
            sphereInstantiation = Instantiate(spherePrefab, new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z), Quaternion.identity);
            sphereInstantiation.name = ("Sphere " + (n + 1));
            //sphereInstantiation.GetComponent<MeshRenderer>().enabled = false;

            if (transform.position.y <= 0.75f)
            {
                //Destroy((Instantiate(cross, transform.position, Quaternion.identity)).gameObject, 0.8f);
                pingAudio.pingAudioSource.clip = pingAudio.noBuzz;
                pingAudio.pingAudioSource.Play();
            }
            else if (transform.position.y > 0.75f && Mathf.Abs((this.gameObject.transform.position.y - other.gameObject.GetComponentInChildren<Transform>().transform.position.y)) < 3f)
            {
                //Destroy((Instantiate(check, transform.position, Quaternion.identity)).gameObject, 0.8f);
                Debug.Log(Mathf.Abs((transform.position.y - other.gameObject.GetComponentInChildren<Transform>().transform.position.y)));
                pingAudio.pingAudioSource.clip = pingAudio.yesPing;
                pingAudio.pingAudioSource.Play();
            } 
            else
            {
                //Destroy((Instantiate(cross, transform.position, Quaternion.identity)).gameObject, 0.8f);
                pingAudio.pingAudioSource.clip = pingAudio.noBuzz;
                pingAudio.pingAudioSource.Play();
            }
            n++;
        }

        if (other.tag == "EndPoint")
        {
            DestroyBalls();

            sphere1 = null;
            sphere2 = null;
            sphere3 = null;
            sphere4 = null;
            sphere5 = null;
            scoreBall1 = null;
            scoreBall2 = null;
            scoreBall3 = null;
            scoreBall4 = null;
            scoreBall5 = null;

            colliderHolder.SetActive(false);
            gameObject.SetActive(false);
            sineBoard.SetActive(false);
        }

    }

    void WaitRespawn()
    {
        if (timesRespawned > 0)
        {
            timesRespawned--;
            Debug.Log(timesRespawned);
            n = 0;
            gameObject.SetActive(true);
            transform.position = initialPos;
            colliderHolder.SetActive(true);
            sineBoard.SetActive(true);
            if (distCheck.check1 == true)
            {
                distCheck.check1b = true;
                distCheck.check2b = true;
                distCheck.check3b = true;
                distCheck.check4b = true;
                distCheck.check5b = true;
            }
        }
        else
        {
            eventHandler.MainCam();
        }
    }

    private void OnDisable()
    {
        Invoke("WaitRespawn", 3f);
        DestroyBalls();
    }


    public void DestroyBalls()
    {
        Destroy(sphere1);
        Destroy(sphere2);
        Destroy(sphere3);
        Destroy(sphere4);
        Destroy(sphere5);
        Destroy(sphere6);
        Destroy(sphere7);
        Destroy(sphere8);
        Destroy(sphere9);
        Destroy(sphere10);


        Destroy(scoreBall1);
        Destroy(scoreBall2);
        Destroy(scoreBall3);
        Destroy(scoreBall4);
        Destroy(scoreBall5);
    }

    public void FindBalls()
    {
        sphere1 = GameObject.Find("Sphere 1");
        sphere2 = GameObject.Find("Sphere 2");
        sphere3 = GameObject.Find("Sphere 3");
        sphere4 = GameObject.Find("Sphere 4");
        sphere5 = GameObject.Find("Sphere 5");
        sphere6 = GameObject.Find("Sphere 6");
        sphere7 = GameObject.Find("Sphere 7");
        sphere8 = GameObject.Find("Sphere 8");
        sphere9 = GameObject.Find("Sphere 9");
        sphere10 = GameObject.Find("Sphere 10");

        scoreBall1 = GameObject.Find("ScoreBall 1");
        scoreBall2 = GameObject.Find("ScoreBall 2");
        scoreBall3 = GameObject.Find("ScoreBall 3");
        scoreBall4 = GameObject.Find("ScoreBall 4");
        scoreBall5 = GameObject.Find("ScoreBall 5");
    }
}
