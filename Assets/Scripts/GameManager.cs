using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
public class GameManager : Singleton<GameManager> {
	// Use this for initialization
	bool won;
	private float currentScore = 0;
	public float CurrentScore{
		get{ 
			return currentScore;
		}
		set{ 
			currentScore = value;
		}
	}
	void Start () {
		TimeCounter.OnTimeOut += GameEnd;
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameEnd(){
		StartCoroutine (EndGameCoroutine());
	}

	IEnumerator EndGameCoroutine(){
		Time.timeScale = 0;
		if (won) {
			//Wining todos here.
		} else {
			//Losing todos here.
		}
		yield return new WaitForSecondsRealtime (3.0f);
		RestartGame ();
	}

	void RestartGame(){
		currentScore = 0;
		TimeCounter.OnTimeOut -= GameEnd;
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}


}
