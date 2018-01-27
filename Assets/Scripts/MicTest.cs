using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MicTest : MonoBehaviour
    {
        AudioSource audioSource;
        
        // Use this for initialization
        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            audioSource.clip = Microphone.Start(null, true, 100, AudioSettings.outputSampleRate);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

