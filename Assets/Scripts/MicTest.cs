using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicTest : MonoBehaviour {

    public float sensitivity = 100;
    public float loudness = 0;
    public AudioSource audioSource;
    BallMovement ballMov;

    public string selectedDevice;

    float timer;

    bool micEnd, micStart;
    // Use this for initialization
    void Start () {
        ballMov = FindObjectOfType<BallMovement>();
        selectedDevice = Microphone.devices[0].ToString();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(selectedDevice, true, 100, 44100);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 20f && !micEnd)
        {
            Microphone.End(selectedDevice);
            micEnd = true;
            Destroy(audioSource.clip);
        }

        if (timer >= 38f && !micStart)
        {
            Debug.Log("mic start");
            audioSource.clip = Microphone.Start(selectedDevice, true, 100, 44100);
            audioSource.loop = true;
            while (!(Microphone.GetPosition(null) > 0)) { }
            audioSource.Play();

            micStart = true;
        }
        loudness = GetAveragedVolume() * sensitivity;
        if (loudness > 10)
        { ballMov.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(ballMov.gameObject.GetComponent<Rigidbody>().velocity.x, 5f, ballMov.gameObject.GetComponent<Rigidbody>().velocity.z); }

    }
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audioSource.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);

        }
        return a / 256;
    }

}
