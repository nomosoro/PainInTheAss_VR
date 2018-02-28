using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
public class GameManager : Singleton<GameManager> {
	// Use this for initialization
	bool won;

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
		TimeCounter.OnTimeOut -= GameEnd;
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}


}
