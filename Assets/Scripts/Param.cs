using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Param : MonoBehaviour {
    public int band;
    public float startScale, scaleMultiplier, soundMultiplier;
    public bool useBuffer;
    Material material;
	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (useBuffer)
        {
            //transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.bandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
            //Color color = new Color(AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band], AudioPeer.audioBandBuffer[band]);
            //material.SetColor("_EmissionColor", color);
            transform.position = new Vector3(transform.position.x, AudioPeer.bandBuffer[band] * soundMultiplier, transform.position.z);
        }

        if (!useBuffer)
        {
            //transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.frequencyBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
            //Color color = new Color(AudioPeer.audioBandBuffer[band], AudioPeer.frequencyBand[band], AudioPeer.audioBandBuffer[band]);
            //material.SetColor("_EmissionColor", color);
            transform.position = new Vector3(transform.position.x, AudioPeer.frequencyBand[band] * soundMultiplier, transform.position.z);
        }

    }
}
