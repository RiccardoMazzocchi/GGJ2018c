using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    public Camera mainCam;
    public Camera battleCamP1;
    public Camera battleCamP2;

    public Transform sineGame;
    float battleTimer;

    private void Awake()
    {
        sineGame = transform.Find("Sine Mini Game");
        //sineGame.gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        mainCam.enabled = true;
        battleCamP1.enabled = false;
        battleCamP2.enabled = false;

        
        
        //sineGame.SetActive(false);
        StartCoroutine("StartSineGame");
    }
	
	// Update is called once per frame
	void Update () {
        battleTimer += Time.deltaTime;
        if (battleTimer >= 5f)
        {
            BattleStart();
        }
    }

    public void BattleStart()
    {
        mainCam.enabled = false;
        battleCamP1.enabled = true;
        battleCamP2.enabled = false;
        
    }

    public void BattleEnd()
    {
        mainCam.enabled = true;
        battleCamP1.enabled = false;

    }

    public void ResetBattleTimer()
    {

    }

    IEnumerator StartSineGame()
    {
        yield return new WaitForSeconds(5f);
        //sineGame = GameObject.Find("Sine Mini Game");

        sineGame.gameObject.SetActive(true);
    }
}
