using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartPool : MonoBehaviour {
	//It controls everything relates to the fart pool.

	private float gasAmount = 0f;
	private float gasMaxAmount = 100;
	private float gasMinAmount = 0f;
	public float GasAmount{get { return gasAmount;}}
	public float GasMaxAmount{get { return gasMaxAmount;}}
	public float GasMinAmount{get { return gasMinAmount;}}
	//Regeneration rate for the gas per second

	#region Singleton 
	public static FartPool Instance;
	void Awake(){
		if (Instance == null) {
			Instance = this;		
		}
	}
	#endregion

	private float _gasRegenRate = 5f;
	public float GasRegenRate{
		get{ 
			return _gasRegenRate;
		}
		set{ 
			_gasRegenRate = value;
		}
	}
	private float _gasReleaseRate = 0f;
	public float GasReleaseRate{
		get{ 
			return _gasReleaseRate;
		}
		set{ 
			_gasReleaseRate = value;
		}
	}
	Coroutine regenCoroutine;
	Coroutine releaseCoroutine;
	void Start(){
		gasAmount = gasMinAmount;
		StartRegeneration ();
	}


	public void StartRelease(){
		if (releaseCoroutine == null) {
			releaseCoroutine = StartCoroutine (ReleaseGas());
		}
	}

	public void StopRelease(){
		if (releaseCoroutine != null) {
			StopCoroutine (releaseCoroutine);
			releaseCoroutine = null;
		}
	}

	public void StartRegeneration(){
		if (regenCoroutine == null) {
			regenCoroutine = StartCoroutine (RegenerateGas());
		}
	}

	public void StopRegeneration(){
		if (regenCoroutine != null) {
			Debug.Log ("regen Routine stopped.");
			StopCoroutine (regenCoroutine);
			regenCoroutine = null;
		}
	}

	IEnumerator RegenerateGas(){
		while(gasAmount<gasMaxAmount){
			gasAmount += _gasRegenRate * Time.deltaTime;
			yield return null;
		}
	//after finish regeneration
		gasAmount = gasMaxAmount;
		regenCoroutine = null;
	}
	IEnumerator ReleaseGas(){
		while(gasAmount>gasMinAmount){
			Debug.Log ("Release fart with rate of " + _gasReleaseRate);
			gasAmount -= _gasReleaseRate * Time.deltaTime;
			yield return null;
		}
		//after finish release
		gasAmount = gasMinAmount;
		releaseCoroutine = null;
	}

}
