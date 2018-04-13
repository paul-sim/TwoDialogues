using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	private Dialog tempDialog;
	public GameObject dialogContinueTriangle;
	Vector2 dialogTriangleDefaultPosition = new Vector2(-62, -16);

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		tempDialog = null;
		dialogContinueTriangle = GameObject.Find("dialogContinueTriangle"); // only one instance in entire game
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void startDialog(Dialog dialog) {

		tempDialog = dialog;
		// tempDialog.speakerBox.text = tempDialog.speaker;
		tempDialog.speechBox.enabled = true;
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
		dialogContinueTriangle.transform.position = dialogTriangleDefaultPosition;

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

		// we have displayed entire sentence so insert the continue dialog triangle
		// insert the triangle near bottom right corner of dialog box
		// var tempRect = ((RectTransform)(tempDialog.speechBox.transform.parent.transform)).rect;
		//var tempRect = ((RectTransform)(tempDialog.speechBox.transform)).rect;

		//float tempWidth = tempRect.width;
		//float tempHeight = tempRect.height;
		/*
		Debug.Log ("width is " + tempWidth);
		Debug.Log ("height is " + tempHeight);
		Debug.Log ("position x is " + tempRect.x);
		Debug.Log ("position y is " + tempRect.y);
		*/

		// Debug.Log ("position y is " + tempRect.position.y);

		// dialogContinueTriangle.transform.position = new Vector2(tempRect.x + tempWidth, tempRect.y + tempHeight);
		// dialogContinueTriangle.transform.position = new Vector2(tempRect.position.x + tempRect.width, tempRect.position.y + tempRect.height);
		// dialogContinueTriangle.transform.position = tempRect.position;
		dialogContinueTriangle.transform.position = (GameObject.Find("CharacterBlack")).transform.position;
		(GameObject.Find("Canvas")).transform.position = (GameObject.Find("CharacterBlack")).transform.position;

	}

	public void endDialog() {
		StopAllCoroutines ();
		sentences.Clear ();
		dialogContinueTriangle.transform.position = dialogTriangleDefaultPosition;
		// tempDialog will not be null if this method was called for when walking away mid conversation
		if (tempDialog != null) {
			tempDialog.speechBox.text = "";
			tempDialog.speechBox.enabled = false; // if enabled, it leaves a thin streak of button sprite
			tempDialog = null;
		}
		FindObjectOfType<CharacterRed> ().enableMovement ();
	}
}
