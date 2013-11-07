using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(50,50,500,450), "Start Menu");
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(80,160,320,80), "Play Game")) {
			Application.LoadLevel(1);
		}
		if(GUI.Button (new Rect(80,320,320,80), "Instructions")) {
			Application.LoadLevel (2);
		}
	}
	
}
