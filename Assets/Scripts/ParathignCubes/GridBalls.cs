using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBalls : MonoBehaviour {

    public GameObject scoreBallPrefab;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateScoreBalls()
    {
        GameObject instantiation = Instantiate(scoreBallPrefab, new Vector3(this.transform.position.x, Random.Range(0f, 8f), this.transform.position.z), Quaternion.identity);
        instantiation.transform.parent = this.gameObject.transform;
        if (this.gameObject.name == "Collider 1")
        {
            instantiation.name = "ScoreBall 1";
        }
        else if (this.gameObject.name == "Collider 2")
        {
            instantiation.name = "ScoreBall 2";
        }
        else if (this.gameObject.name == "Collider 3")
        {
            instantiation.name = "ScoreBall 3";
        }
        else if (this.gameObject.name == "Collider 4")
        {
            instantiation.name = "ScoreBall 4";
        }
        else if (this.gameObject.name == "Collider 5")
        {
            instantiation.name = "ScoreBall 5";
        }
    }

    private void OnEnable()
    {
        GenerateScoreBalls();
    }
}
