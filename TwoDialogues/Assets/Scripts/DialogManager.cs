using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	private Dialog tempDialog;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		tempDialog = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startDialog(Dialog dialog) {

		tempDialog = dialog;
		// tempDialog.speakerBox.text = tempDialog.speaker;
		sentences.Clear();

		foreach (string sentence in dialog.speech) {
			sentences.Enqueue(sentence);
		}

		displayNextSentence ();
	}

	public string displayNextSentence() {

		// close the dialog if no sentences are left to show
		if (sentences.Count == 0) {

			endDialog ();
			return "noMoreSentences";
		}

		string sentence = sentences.Dequeue ();

		StopAllCoroutines ();
		StartCoroutine ("typeSentence", sentence);

		return "hasMoreSentences";
	}

	IEnumerator typeSentence (string sentence) {
		tempDialog.speechBox.text = "";
		int outputCount = 0;

		for (int i = 0; i < sentence.Length; ) {

			if (sentence.Length - i < 2) {
				outputCount = sentence.Length - i;
			} else {
				outputCount = 2;
			}

			for (int j = 0; j < outputCount; ++i, ++j) {
				tempDialog.speechBox.text += sentence [i];
			}

			yield return null;
		}

	}

	public void endDialog() {
		StopAllCoroutines ();
		sentences.Clear ();
		tempDialog.speechBox.text = "";
		FindObjectOfType<CharacterRed> ().enableMovement ();
	}
}
