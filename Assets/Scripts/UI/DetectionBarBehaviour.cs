using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetectionBarBehaviour : MonoBehaviour {
	Image detectionBarImage;
	public PassengerController passenger;
	// Use this for initialization
	void Start () {
		detectionBarImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		detectionBarImage.fillAmount = passenger.GetDetectionPercent ();
	}
}
