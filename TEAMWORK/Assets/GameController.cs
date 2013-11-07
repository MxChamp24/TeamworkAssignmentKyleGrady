using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject aCube;
	private int gridWidth = 8;
	private int gridHeight = 5;
	private GameObject[,] allCubes;
	// Use this for initialization
	void Start () {
		//creates the array's width and height to be instantiated
		allCubes = new GameObject [gridWidth,gridHeight];
		//make the 8 x 5 grid of white cubes
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++){
				allCubes[x,y] = (GameObject) Instantiate(aCube, new Vector3(0 + 2*x, y*2, -10), Quaternion.identity);
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	
	void OnGUI() {
		GUI.Label(new Rect(10,10,120,20), "Timer");
	}
}
