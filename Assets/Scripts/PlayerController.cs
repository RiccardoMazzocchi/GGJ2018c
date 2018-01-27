using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    DistanceChecker distChecker;
    public Animator anim;
	// Use this for initialization
	void Start () {
        distChecker = FindObjectOfType<DistanceChecker>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
