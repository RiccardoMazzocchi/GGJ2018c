using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string SENSITIVITY_KEY = "sensitivity";

    public static void SetSensitivity(float sensitivity)
    {
        if (sensitivity >= 1f && sensitivity <= 500f)
        {
            PlayerPrefs.SetFloat(SENSITIVITY_KEY, sensitivity);
        }
        else
        {
            Debug.LogError("Sensitivity out of range");
        }
    }

    public static float GetSensitivity()
    {
        return PlayerPrefs.GetFloat(SENSITIVITY_KEY);
    }
}
