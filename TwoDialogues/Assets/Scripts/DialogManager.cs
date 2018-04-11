﻿using System.Collections;
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

	public void displayNextSentence() {

		// close the dialog if no sentences are left to show
		if (sentences.Count == 0) {

			endDialog ();
			return;
		}

		string sentence = sentences.Dequeue ();

		StopAllCoroutines ();
		StartCoroutine ("typeSentence", sentence);
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

		/*
		foreach (char letter in sentence.ToCharArray()) {
			tempDialog.speechBox.text += letter;

			yield return null;
		} */
	}

	public void endDialog() {
		tempDialog.speechBox.text = "";
	}
}
