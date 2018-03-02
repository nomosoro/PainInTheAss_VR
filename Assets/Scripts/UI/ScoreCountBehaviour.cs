using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCountBehaviour : MonoBehaviour {
	Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = "You farted : + \n\n";
		scoreText.text += GameManager.Instance.CurrentScore.ToString ("F1") + "\n\n";
		scoreText.text += "Gallon delicious gas.";
	}
}
