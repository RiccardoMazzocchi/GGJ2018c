using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Transform target;
    public float speed;

    float journeyLength;
    float startTime;

    Vector3 initialPos;

    public GameObject pointerPrefab;
    public GameObject instantiation;

    int n = 0;

    DistanceChecker distCheck;


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

    float dist1, dist2, dist3, dist4, dist5;

    GridBalls gridBalls;
    EventHandler eventHandler;

    public GameObject colliderHolder;

    bool respawned;

    float battleTimer;
    // Use this for initialization
    void Start () {
        startTime = Time.time;

        distCheck = FindObjectOfType<DistanceChecker>();
        gridBalls = FindObjectOfType<GridBalls>();
        eventHandler = FindObjectOfType<EventHandler>();

        initialPos = transform.position;

        Invoke("DestroyBalls", 4f);
    }
	
	// Update is called once per frame
	void Update () {




        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        float distanceToEnd = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToEnd <= 1f)
        {
            colliderHolder.SetActive(false);

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


            gameObject.SetActive(false);


        }

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

    }

    private void OnTriggerEnter(Collider other)
    {
        
        instantiation = Instantiate(pointerPrefab, new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z), Quaternion.identity);
        instantiation.name = ("Sphere " + (n + 1));
        n++;
        Debug.Log("test");

    }

    void WaitRespawn()
    {
        if (!respawned)
        {
            n = 0;
            gameObject.SetActive(true);
            transform.position = initialPos;
            distCheck.check1b = true;
            distCheck.check2b = true;
            distCheck.check3b = true;
            distCheck.check4b = true;
            distCheck.check5b = true;
            colliderHolder.SetActive(true);
            respawned = true;
        }
        else
        {
            eventHandler.BattleEnd();
        }
    }

    private void OnDisable()
    {
        Invoke("WaitRespawn", 3f);
    }


    public void DestroyBalls()
    {
        Destroy(sphere1);
        Destroy(sphere2);
        Destroy(sphere3);
        Destroy(sphere4);
        Destroy(sphere5);

        Destroy(scoreBall1);
        Destroy(scoreBall2);
        Destroy(scoreBall3);
        Destroy(scoreBall4);
        Destroy(scoreBall5);
    }
}
