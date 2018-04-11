using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderEnterTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			// Debug.Log ("entered collision.");

			FindObjectOfType<DialogTrigger> ().triggerDialog ();
		}
	}
}
