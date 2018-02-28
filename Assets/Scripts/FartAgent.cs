using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FartPool))]
public class FartAgent : MonoBehaviour {
	FartPool fartPool;
	float fartShrinkRate = .5f;
	float fartExpandRate = 1;
	Vector3 FartZoneMaxScale = new Vector3(10,10,10);

	void Start(){
		fartPool = GetComponent<FartPool> ();
	}
	void Update(){
		if (fartPool.GasReleaseRate > 0) {
			transform.localScale += fartExpandRate * Time.deltaTime * Vector3.one *  fartPool.GasReleaseRate/FartEmitter.EmitRate;
			if (transform.localScale.sqrMagnitude > FartZoneMaxScale.sqrMagnitude) {
				transform.localScale = FartZoneMaxScale;
			}
		} else {
			transform.localScale -= fartShrinkRate * Time.deltaTime * Vector3.one;
			if (transform.localScale.x <= 0) {
				transform.localScale = Vector3.zero;
			}
		}
	}

}
