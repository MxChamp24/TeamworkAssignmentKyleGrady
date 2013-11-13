using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject aCube;
	private int gridWidth = 8;
	private int gridHeight = 5;
	private GameObject[,] allCubes;
	public float turnCount = 0f;
	public float turnLength = 2f;
	public CubeBehavior activeCube = null;
	public int showTime;
	public GameObject displayNextCube;
	public int nextColor;
	
	//colors as numbers
	/*public int blackNumber = 1;
	public int blueNumber = 2;
	public int greenNumber = 3;
	public int redNumber = 4;
	public int yellowNumber = 5;*/
	
	// Use this for initialization
	void Start () {
		//creates the array's width and height to be instantiated
		allCubes = new GameObject [gridWidth,gridHeight];
		//make the 8 x 5 grid of white cubes
		for (int x = 0; x < gridWidth; x++) {
			for (int y = 0; y < gridHeight; y++){
				allCubes[x,y] = (GameObject) Instantiate(aCube, new Vector3(0 + 2*x, y*2, -10), Quaternion.identity);
				allCubes[x,y].GetComponent<CubeBehavior>().myController = this;
				allCubes[x,y].GetComponent<CubeBehavior>().myX = x;
				allCubes[x,y].GetComponent<CubeBehavior>().myY = y;
			}
		}
		
		displayNextCube = GameObject.Find("NextCube");
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		showTime = 60 - (int) Time.time;
		if (Time.time >= 20f) {
			//Application.LoadLevel(2);
			
		}
		
		turnCount += Time.deltaTime;
		
		if (turnCount >= turnLength) {
			turnCount = 0;
			nextColor = (int) Random.Range(1,5);
			displayNextCube.renderer.enabled = true;
			if (nextColor == 1){
				displayNextCube.renderer.material.color = Color.black;
			}
			if (nextColor == 2){
				displayNextCube.renderer.material.color = Color.blue;
			}
			if (nextColor == 3){
				displayNextCube.renderer.material.color = Color.green;
			}
			if (nextColor == 4){
				displayNextCube.renderer.material.color = Color.red;
			}
			if (nextColor == 5){
				displayNextCube.renderer.material.color = Color.yellow;
			}
		}
		if (nextColor != -1){
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				IsThereSpace(0);
			}		
			else if (Input.GetKeyDown(KeyCode.Alpha2)) {
				IsThereSpace(1);
			}		
			else if (Input.GetKeyDown(KeyCode.Alpha3)) {
				IsThereSpace(2);
			}		
			else if (Input.GetKeyDown(KeyCode.Alpha4)) {
				IsThereSpace(3);
			}		
			else if (Input.GetKeyDown(KeyCode.Alpha5)) {
				IsThereSpace(4);
			}
		}
		
		
	}
	
	public void IsThereSpace(int row) {
		int availableSpaces = 0;
		ArrayList openSlots = new ArrayList();
		for(int i = 0; i < 8; i++){
			if(allCubes[i, row].GetComponent<CubeBehavior>().myColor == 0){
				availableSpaces++;
				openSlots.Add(allCubes[i, row]);
			}
		}
		if(availableSpaces <= 0){
			print("you are bad at this");
		}
		else{
			(openSlots[Random.Range (0, availableSpaces - 1)] as GameObject).GetComponent<CubeBehavior>().setColor(nextColor);
			nextColor = -1;
			displayNextCube.renderer.enabled = false;
		}
		
		
	}
	
	
	void OnGUI() {
		GUI.Label(new Rect(10,10,120,20), "Timer: " + showTime.ToString());
		GUI.Label(new Rect(500,10,120,20), "Next Cube:");
		GUI.Label(new Rect(1000,10,120,20), "Score:");
	}
	
	public void OnCubeClicked (CubeBehavior cube) {
		if (cube.myColor == 0) {
			if(activeCube != null) {
				if(Mathf.Abs (activeCube.myX - cube.myX) <= 1 && Mathf.Abs(activeCube.myY - cube.myY) <= 1){
					cube.setColor(activeCube.myColor);
					activeCube.setColor(0);
				}
					
			}
		}
		else {
			(cube.GetComponent ("Halo") as Behaviour).enabled = true;
			(activeCube.GetComponent ("Halo") as Behaviour).enabled = false;
			activeCube = cube;
		}
		
	
	}
	
	
}
