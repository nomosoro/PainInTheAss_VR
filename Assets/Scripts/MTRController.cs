using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTRController : MonoBehaviour {

	Animator animator;

	void Start(){
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (animator.GetBool ("DoorOpen")) {
				animator.SetBool ("DoorOpen", false);
			} else {
				animator.SetBool ("DoorOpen",true);
			}
		}
	}

}
