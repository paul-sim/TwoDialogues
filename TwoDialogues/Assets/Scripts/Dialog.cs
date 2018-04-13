using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog {
	public string speaker;

	[TextArea(3, 10)]
	public string[] speech;
	// public Text speakerBox;
	public Text speechBox;

}
