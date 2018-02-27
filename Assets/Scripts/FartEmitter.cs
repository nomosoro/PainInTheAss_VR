using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SteamVR_TrackedObject))]
public class FartEmitter : MonoBehaviour {
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private SteamVR_Controller.Device controller{get{ return SteamVR_Controller.Input ((int)trackedObj.index);}}
	private SteamVR_TrackedObject trackedObj;
	private AudioSource audioSource;
	public AudioClip[] fartClips;
	public float emitRate = 10.0f;
	FartPool fartPool;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		audioSource = GetComponent<AudioSource> ();
		fartPool = FartPool.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		if (controller == null) {
			Debug.Log ("Controller not initialized");
			return;
		}

		if (controller.GetPressDown (triggerButton)&&fartClips!=null) {
			PlayFartSound ();
			EmitFart ();
		}
		if (controller.GetPressUp (triggerButton)) {
			EndEmittingFart ();
		}
	}

	void PlayFartSound(){
		audioSource.clip = fartClips[new System.Random().Next(0,fartClips.Length-1)];
		audioSource.Play ();
	}
	void EmitFart(){
		fartPool.StopRegeneration ();
		fartPool.StartRelease ();
		fartPool.GasReleaseRate += emitRate;
	}

	void EndEmittingFart(){
		fartPool.GasRegenRate -= emitRate;
		if (fartPool.GasRegenRate <= 0) {
			fartPool.StopRelease ();
			fartPool.StartRegeneration ();
		}
	}
}
