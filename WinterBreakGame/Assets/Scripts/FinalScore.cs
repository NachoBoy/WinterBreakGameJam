using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = ScoreManager.score.ToString();
    }
	
}
