using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class AudioPeer : MonoBehaviour {
    AudioSource _audioSource;

    public AudioClip audioClip;
    public bool useMicrophone;
    public string selectedDevice;

    public static float[] samples = new float[512];
    public static float[] frequencyBand = new float[8];
    public static float[] bandBuffer = new float[8];
    public static float[] bufferDecrease = new float[8];

    float[] freqBandHighest = new float[8];
    public static float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];


    float[] audioData = new float[128];


    // Use this for initialization
    void Start () {
        _audioSource = GetComponent<AudioSource>();
        
        if (useMicrophone)
        {
            if (Microphone.devices.Length > 0)
            {
                selectedDevice = Microphone.devices[0].ToString();
                _audioSource.clip = Microphone.Start(selectedDevice, true, 5, 22050);
                GetComponent<AudioSource>().loop = true;
                GetComponent<AudioSource>().mute = false;
                while (!(Microphone.GetPosition(selectedDevice) > 0)) { }
                _audioSource.Play();
                audioClip = GetComponent<AudioClip>();
            } else
            {
                useMicrophone = false;
            }
        }
        if (!useMicrophone)
        {
            _audioSource.clip = audioClip;
        }
	}


    //get data from microphone into audioclip

    // Update is called once per frame
    void Update () {
       GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();

    }





    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (frequencyBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = frequencyBand[i];
            }

            audioBand[i] = (frequencyBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }
    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if (frequencyBand [g] > bandBuffer [g])
            {
                bandBuffer[g] = frequencyBand[g];
                bufferDecrease[g] = 0.005f;
            }
            if (frequencyBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;
        
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            frequencyBand[i] = average * 25;
        }
    }






}
