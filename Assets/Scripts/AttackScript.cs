using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public float timer;
    EventHandler eventHandler;
    DistanceChecker distChecker;
    GameObject player1, player2;

    public bool attack1, attack2, attack3, attack4, attack5, fightStart;
    bool player1lifeBool, player2lifeBool;
    float speed = .1f;
    public int player1life = 6;
    public int player2life = 6;

    public Material face1hit, face1attack, face1idle, face2hit, face2attack, face2idle;
    HealthScript healthScript;
    GameObject face1, face2;


    AudioSource hitAudio;
    public AudioClip hitClip;
    // Use this for initialization
    void Start()
    {
        hitAudio = GetComponent<AudioSource>();
        
        face1 = GameObject.Find("face1");
        face2 = GameObject.Find("face2");
        healthScript = FindObjectOfType<HealthScript>();
        eventHandler = FindObjectOfType<EventHandler>();
        distChecker = FindObjectOfType<DistanceChecker>();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        eventHandler.MainCam();
        Debug.Log("Player 1 life " + player1life);
        Debug.Log("Player 2 life " + player2life);

        
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("attack timer " + timer);
        if (timer <= 5f)
        {
            player1.transform.position = Vector3.Lerp(player1.transform.position, new Vector3(-4.5f, -9.1f, 0f), .1f);
            player2.transform.position = Vector3.Lerp(player2.transform.position, new Vector3(5.5f, -9.1f, 0f), .1f);
        }

        timer += Time.deltaTime;
        
        if (timer >= 2f && !attack1)
        {



            if (distChecker.dist1 < distChecker.dist1b)
            {
                
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player1.GetComponent<Animator>().SetBool("isPunching", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;

                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player1.GetComponent<Animator>().SetBool("isKicking", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;

                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP2Life", 0.35f);
                player2life--;
            }
            else
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player2.GetComponent<Animator>().SetBool("isPunching", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player2.GetComponent<Animator>().SetBool("isKicking", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP1Life", 0.35f);
                player1life--;
            }
            attack1 = true;
            Invoke("ResetAnimations", 1f);
        }
        if (timer >= 4.5f && !attack2)
        {
            Debug.Log("attack 2");

            if (distChecker.dist2 < distChecker.dist2b)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player1.GetComponent<Animator>().SetBool("isPunching", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;
                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player1.GetComponent<Animator>().SetBool("isKicking", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;
                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP2Life", 0.35f);
                player2life--;
            }
            else
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player2.GetComponent<Animator>().SetBool("isPunching", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player2.GetComponent<Animator>().SetBool("isKicking", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP1Life", 0.35f);
                player1life--;
            }
            attack2 = true;

            Invoke("ResetAnimations", 1f);
        }
        if (timer >= 7f && !attack3)
        {
            Debug.Log("attack 3");

            if (distChecker.dist3 < distChecker.dist3b)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player1.GetComponent<Animator>().SetBool("isPunching", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;
                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player1.GetComponent<Animator>().SetBool("isKicking", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;
                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP2Life", 0.35f);
                player2life--;
            }
            else
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player2.GetComponent<Animator>().SetBool("isPunching", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player2.GetComponent<Animator>().SetBool("isKicking", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP1Life", 0.35f);
                player1life--;
            }
            attack3 = true;

            Invoke("ResetAnimations", 1f);
        }
        if (timer >= 9.5f && !attack4)
        {
            Debug.Log("Attack 4");

            if (distChecker.dist4 < distChecker.dist4b)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player1.GetComponent<Animator>().SetBool("isPunching", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;
                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player1.GetComponent<Animator>().SetBool("isKicking", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;
                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP2Life", 0.35f);
                player2life--;

            }
            else
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player2.GetComponent<Animator>().SetBool("isPunching", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player2.GetComponent<Animator>().SetBool("isKicking", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP1Life", 0.35f);
                player1life--;
            }
            attack4 = true;

            Invoke("ResetAnimations", 1f);
        }
        if (timer >= 12f && !attack5)
        {
            Debug.Log("Attack 5");

            if (distChecker.dist5 < distChecker.dist5b)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player1.GetComponent<Animator>().SetBool("isPunching", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;
                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player1.GetComponent<Animator>().SetBool("isKicking", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1attack;
                    player2.GetComponent<Animator>().SetBool("isHit", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP2Life", 0.35f);
                player2life--;
            }
            else
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    player2.GetComponent<Animator>().SetBool("isPunching", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }
                else
                {
                    player2.GetComponent<Animator>().SetBool("isKicking", true);
                    face2.GetComponent<SkinnedMeshRenderer>().material = face2attack;
                    player1.GetComponent<Animator>().SetBool("isHit", true);
                    face1.GetComponent<SkinnedMeshRenderer>().material = face1hit;
                    hitAudio.clip = hitClip;
                    hitAudio.Play();
                }

                Invoke("TakeP1Life", 0.35f);
                player1life--;
            }
            attack5 = true;
        }

        if (attack5)
        {
            Invoke("ResetAnimations", 0.75f);
            Invoke("SpecialAttack", 0.75f);
        }

        if (timer >= 17f)
        {
            ResetAnimations();
            ResetPosition();
        }
    }

    void SpecialAttack()
    {
        if (player1life <= 0)
        {
            player2.GetComponent<Animator>().SetBool("Special", true);
            player1.GetComponent<Animator>().SetBool("SpecialHit", true);
            Invoke("ResetAnimations", 3f);
            Invoke("Win", 3.5f);
        }
        if (player2life <= 0)
        {
            player1.GetComponent<Animator>().SetBool("Special", true);
            player2.GetComponent<Animator>().SetBool("SpecialHit", true);
            Invoke("ResetAnimations", 3f);
            Invoke("Win", 3.5f);
        }
    }

    void Win()
    {
        if (player1life <= 0)
        {
            player2.GetComponent<Animator>().SetBool("hasWon", true);
        } else if (player2life <= 0)
        {
            player1.GetComponent<Animator>().SetBool("hasWon", true);
        }
    }

    void ResetAnimations()
    {
        player1.GetComponent<Animator>().SetBool("isHit", false);
        player1.GetComponent<Animator>().SetBool("isKicking", false);
        player1.GetComponent<Animator>().SetBool("isPunching", false);
        player1.GetComponent<Animator>().SetBool("Special", false);
        player2.GetComponent<Animator>().SetBool("isHit", false);
        player2.GetComponent<Animator>().SetBool("isKicking", false);
        player2.GetComponent<Animator>().SetBool("isPunching", false);
        player2.GetComponent<Animator>().SetBool("Special", false);

        face1.GetComponent<SkinnedMeshRenderer>().material = face1idle;
        face2.GetComponent<SkinnedMeshRenderer>().material = face2idle;

    }

    void ResetFight()
    {
        attack1 = false;
        attack2 = false;
        attack3 = false;
        attack4 = false;
        attack5 = false;
    }

    void ResetPosition()
    {
        player1.transform.position = Vector3.Lerp(player1.transform.position, new Vector3(-16f, -9.1f, 0f), .1f);
        player2.transform.position = Vector3.Lerp(player2.transform.position, new Vector3(17f, -9.1f, 0f), .1f);
    }

    void Deactivation()
    {
        this.gameObject.SetActive(false);
    }

    void TakeP1Life()
    {
        healthScript.healthSprites1[player1life].enabled = false;
    }
    void TakeP2Life()
    {
        healthScript.healthSprites2[player2life].enabled = false;
    }
}
