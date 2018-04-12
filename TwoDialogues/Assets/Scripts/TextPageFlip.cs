using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPageFlip : MonoBehaviour {

	private DialogManager dm;
	public bool makePlayerStay;
	public DialogState dialogState; 

	public enum DialogState {
		startingDialog,
		midDialog,
		notInDialog
	};

	void Start () {
		dm = FindObjectOfType<DialogManager> ();
		dialogState = DialogState.notInDialog;
	}
		
	public void flipPage() {
		// dormant dialog is now active.. starting dialog
		if (dialogState == DialogState.notInDialog) {
			dialogState = DialogState.startingDialog;
		}

		if (dialogState == DialogState.startingDialog) {
			FindObjectOfType<DialogTrigger> ().triggerDialog ();
			if (makePlayerStay) {
				FindObjectOfType<CharacterRed> ().disableMovement ();
			}
			// dialog has begun, is in mid dialog
			dialogState = DialogState.midDialog;
		}
		else if (dialogState == DialogState.midDialog) {
			if (dm.displayNextSentence () == "noMoreSentences") {
				// dialog is done
				dialogState = DialogState.notInDialog;
			}
		}
	}
}
