using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingAudio : MonoBehaviour {

    public AudioSource pingAudioSource;
    public AudioClip yesPing, noBuzz;
	// Use this for initialization
	void Start () {
        pingAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
