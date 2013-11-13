using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
	public GameController myController;
	public bool amIGray = false;
	public int myColor = 0;
	public int myX;
	public int myY;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDown() {
		if (!amIGray) {
			myController.OnCubeClicked(this);
		}
	}
	
	public void setColor (int whatColor){
		myColor = whatColor;
		if (whatColor == 1){
			renderer.material.color = Color.black;
		}
		if (whatColor == 2){
			renderer.material.color = Color.blue;
		}
		if (whatColor == 3){
			renderer.material.color = Color.green;
		}
		if (whatColor == 4){
			renderer.material.color = Color.red;
		}
		if (whatColor == 5){
			renderer.material.color = Color.yellow;
		}
	}
	
}