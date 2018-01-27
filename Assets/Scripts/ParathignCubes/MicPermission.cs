using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicPermission : MonoBehaviour {

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {

        }
        else
        {
            Debug.Log("errorrrrr");
        }
    }
}
