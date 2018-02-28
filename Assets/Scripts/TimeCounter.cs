using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour {
	public delegate void TimeOutActions();
	public static event TimeOutActions OnTimeOut;
	public float MaxTime = 60f;
	private float elapsedTime = 0f;
	public float ElapsedTime {
		get{
			return elapsedTime;
		}
		set{ 
			elapsedTime = value;
		}
	}

	#region Singleton 
	public static TimeCounter Instance;
	void Awake(){
		if (Instance == null) {
			Instance = this;		
		}
	}
	#endregion

	void Update(){
		elapsedTime += Time.deltaTime;
		if (elapsedTime > MaxTime) {
			elapsedTime = MaxTime;
			OnTimeOut ();
		}
	}

}
