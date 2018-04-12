using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoxColliderEnterTrigger : MonoBehaviour {

	private bool inTalkTriggerDistance;
	TextPageFlip tpf;

	void Start() {
		inTalkTriggerDistance = false;
		tpf = FindObjectOfType<TextPageFlip> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			inTalkTriggerDistance = true;
		}
	}
		
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			inTalkTriggerDistance = false;
			FindObjectOfType<DialogManager> ().endDialog ();
			tpf.dialogState = TextPageFlip.DialogState.notInDialog;
		}
	}
		
	void Update() {
		// start dialog if key is pressed and character is within conversation distance
		if (Input.GetKeyDown (KeyCode.LeftArrow) && inTalkTriggerDistance) {
			tpf.flipPage ();
		}
	}
}
