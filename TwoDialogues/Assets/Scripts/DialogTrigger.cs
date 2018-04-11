using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogTrigger : MonoBehaviour {

	public Dialog dialog;

	public void triggerDialog () {
		FindObjectOfType<DialogManager>().startDialog(dialog);
	}
}
