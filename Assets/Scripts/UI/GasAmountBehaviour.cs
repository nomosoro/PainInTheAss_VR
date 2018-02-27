using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasAmountBehaviour : MonoBehaviour {
	FartPool fartPool;
	Text gasAmountText;
	// Use this for initialization
	void Start () {
		fartPool = FartPool.Instance;
		gasAmountText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		gasAmountText.text = "Gas Amount : \n\n";
		gasAmountText.text += fartPool.GasAmount.ToString("F1") + " / " + fartPool.GasMaxAmount.ToString("F1");
	}
}
