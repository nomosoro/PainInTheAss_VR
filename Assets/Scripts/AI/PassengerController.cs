using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utilities;
[RequireComponent(typeof(NavMeshAgent))]
public class PassengerController : MonoBehaviour {

	NavMeshAgent agent;
	public PassengerGoalPoint goalPoint;
	Coroutine DetectionRaisingCoroutine;
	Coroutine DetectionDroppingCoroutine;
	Coroutine HaltCoroutinue;
	float maxDetectionLevel = 100.0f;
	float minDetectionLevel = 0f;
	float detectionLevel = 0f;
	public float detectionRaiseRate = 10.0f;
	public float detectionDropRate = 15.0f;
	public float DetectionLevel{ 
		get{
			return detectionLevel; 
		}
		set{ 
			detectionLevel = value;
		}
	}

	void Start () {
		if (goalPoint == null) {
			goalPoint = ArrayHelpers.GetRandomValue<GameObject>(GameObject.FindGameObjectsWithTag ("PassengerGoalPoint")).transform.GetComponent<PassengerGoalPoint>();
		}
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (goalPoint.transform.position);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log (collider.tag);
		if (collider.tag == "FartAgent") {
			agent.isStopped = true;
			StartDetection ();
		}
		if(collider.tag == "PassengerGoalPoint"){
			StopAllCoroutines ();
			Destroy (gameObject);
		}
	}
	void OnTriggerExit(Collider collider){
		if (collider.tag == "FartAgent") {
			StopDetection ();
			if (HaltCoroutinue == null) {
				HaltCoroutinue = StartCoroutine (HaltForSeconds(3f));
			}
		}
	}

	public void StartDetection(){
		DetectionRaisingCoroutine = StartCoroutine (RaiseDetectionCoroutine());
		transform.LookAt (Camera.main.transform);
		if (DetectionDroppingCoroutine != null) {
			StopCoroutine (DetectionDroppingCoroutine);
		}
		DetectionDroppingCoroutine = null;
	}
	public void StopDetection(){
		DetectionDroppingCoroutine =StartCoroutine (DropDetectionCoroutine());
		if (DetectionRaisingCoroutine != null) {
			StopCoroutine (DetectionRaisingCoroutine);
		}
		DetectionRaisingCoroutine = null;
	}

	IEnumerator HaltForSeconds(float haltTime){
		agent.isStopped = true;
		yield return new WaitForSeconds (haltTime);
		agent.isStopped = false;
		HaltCoroutinue = null;
	}
	IEnumerator RaiseDetectionCoroutine(){
		while(detectionLevel < maxDetectionLevel){
			detectionLevel += detectionRaiseRate * Time.deltaTime;
			yield return null;
		}
		OnFullDetection ();
		detectionLevel = maxDetectionLevel;
		DetectionRaisingCoroutine = null;
	}
	IEnumerator DropDetectionCoroutine(){
		while (detectionLevel > minDetectionLevel) {
			detectionLevel -= detectionDropRate * Time.deltaTime;
			yield return null;
		}
		detectionLevel = minDetectionLevel;
		DetectionDroppingCoroutine = null;
	}

	public float GetDetectionPercent(){
		return (detectionLevel - minDetectionLevel) / maxDetectionLevel;
	}

	public void OnFullDetection(){
		GameManager.Instance.GameEnd ();
	}
}
