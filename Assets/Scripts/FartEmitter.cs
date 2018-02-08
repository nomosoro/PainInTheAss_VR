using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartEmitter : MonoBehaviour {
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;


	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;


	private SteamVR_Controller.Device controller{get{ return SteamVR_Controller.Input ((int)trackedObj.index);}}
	private SteamVR_TrackedObject trackedObj;

	private AudioSource audioSource;

	public AudioClip[] fartClips;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log ("Controller not initialized");
			return;
		}

		if (controller.GetPressDown (triggerButton)&&fartClips!=null) {
			audioSource.clip = fartClips[new System.Random().Next(0,fartClips.Length-1)];
			audioSource.Play ();
		}
	}
}
