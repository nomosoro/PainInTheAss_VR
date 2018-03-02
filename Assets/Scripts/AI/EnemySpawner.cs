using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class EnemySpawner : MonoBehaviour {

	public GameObject[] EnemyPrefabs;
	GameObject[] SpawnPoints;
	Transform NextSpawnPoint;
	public float SpawnEnemyCooldown = 2.0f;
	// Use this for initialization
	void Start () {
		SpawnPoints = GameObject.FindGameObjectsWithTag ("PassengerSpawnPoint");
		StartCoroutine (SpawnEnemyCoroutine());
	}

	void RandomizeNextSpawnPoint(){
		NextSpawnPoint = ArrayHelpers.GetRandomValue<GameObject>(SpawnPoints).transform;
	}
	void SpawnRandomEnemy(){
		Instantiate (ArrayHelpers.GetRandomValue<GameObject>(EnemyPrefabs),NextSpawnPoint.position,NextSpawnPoint.rotation,transform);
	}

	IEnumerator SpawnEnemyCoroutine(){
		while(true){
			RandomizeNextSpawnPoint ();
			SpawnRandomEnemy ();
			yield return new WaitForSeconds (SpawnEnemyCooldown);
		}
	}
}
