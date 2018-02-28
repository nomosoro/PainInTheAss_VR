using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCounterBehaviour : MonoBehaviour {

	Text timeCounterText;
	TimeCounter timeCounter;
	// Use this for initialization
	void Start () {
		timeCounter = TimeCounter.Instance;
		timeCounterText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		timeCounterText.text = "Time Left : \n\n";
		timeCounterText.text += (timeCounter.MaxTime-timeCounter.ElapsedTime).ToString("F1") + " / " + timeCounter.MaxTime.ToString("F1");
	}

}
