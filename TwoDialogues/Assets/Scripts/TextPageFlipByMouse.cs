using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* for bit of context, this script was given to the UI Panel Object. The UI Panel Object also
 * had the box collider object
 * */
public class TextPageFlipByMouse : MonoBehaviour {

	BoxCollider2D bc;
	bool mouseInPanel;
	DialogManager dm;

	void Start () {
		bc = gameObject.GetComponent<BoxCollider2D> ();
		mouseInPanel = false;
		dm = FindObjectOfType<DialogManager> ();
	}

	void Update() {
		// if user clicks inside dialog bubble, "flip the page"
		if (Input.GetMouseButtonDown (0) && mouseInPanel) {
			dm.displayNextSentence ();
		}
	}

	void OnMouseEnter () {
		mouseInPanel = true;

	}

	void OnMouseExit () {
		mouseInPanel = false;
	}

	void FixedUpdate () { 
		// resize clickable "flipping the page" dialog box collider 
		bc.size = new Vector2(((RectTransform)gameObject.transform).rect.width, ((RectTransform)gameObject.transform).rect.height);
	}
}
