using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour {

    
    public TMP_Dropdown micSelectionDropdown;
    public Slider micSensitivitySlider;
    public string microphone;

    private List<string> options = new List<string>();

    public GameSettings gameSettings;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        micSensitivitySlider.value = PlayerPrefsManager.GetSensitivity();
    }

    private void OnEnable()
    {
        gameSettings = new GameSettings();


        foreach (string device in Microphone.devices)
        {
            if (microphone == null)
            {
                microphone = device;
            }
            options.Add(device);
        }

        micSelectionDropdown.AddOptions(options);
        micSelectionDropdown.onValueChanged.AddListener(delegate { OnMicSelectionDropdown(); });
    }

    public void OnMicSensitivitySlide()
    {
        PlayerPrefsManager.SetSensitivity(micSensitivitySlider.value);
    }

    public void OnMicSelectionDropdown()
    {

    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {
        
    }

    
}
