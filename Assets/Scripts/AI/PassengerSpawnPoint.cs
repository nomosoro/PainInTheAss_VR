using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawnPoint : MonoBehaviour {


	void OnDrawGizmos(){
		Color c = new Color (0,255,0,.3f);
		Gizmos.color = c;
		Gizmos.DrawCube (transform.position,Vector3.one/2);
	}
}
