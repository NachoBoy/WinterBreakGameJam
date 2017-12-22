using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float timeLeft = 180f; //time for level 
    Text text;
    private int timeLeftInt;

	// Use this for initialization
	void Awake() {
        text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftInt = (int)timeLeft;
        text.text = (timeLeftInt.ToString());
        if(timeLeft < 0)
        {
            SceneManager.LoadScene("LarkTestScene");
        }
	}
}
