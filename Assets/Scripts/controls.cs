using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GamepadInput;

public class controls : MonoBehaviour {


	//public GameObject depthFetch = GameObject.Find("Genesis");
	//public GameObject[][] masterArray = new GameObject[depthFetch.GetComponent<Fractal>().maxDepth][];

	public GameObject[] levelOne;
	public GameObject[] levelTwo;
	public GameObject[] levelThree;
	public GameObject[] levelFour;
	public GameObject[] levelFive;
	public GameObject[] levelSix;
	public GameObject[][] masterArray = new GameObject[3][];
	public GameObject[] selectedOrbital;


	public GameObject groupedOne;
	public GameObject groupedTwo;
	public GameObject groupedThree;

	public List<Vector3> originalOne;
	public List<Vector3> originalTwo;
	public List<Vector3> originalThree;
	public List<Quaternion> rotateOne;
	public List<Quaternion> rotateTwo;
	public List<Quaternion> rotateThree;
	public List<Quaternion> groupReset;


	


	//how can i make the size of masterArray dynamic? i want to be able to change max depth and have things work 

	public int childCounter = 0; 
	public int triggerCounter = 1;
	public int spinSpeed = 10;


	bool childBuilding = true;
	bool RT_isAxisInUse = false;
	bool LT_isAxisInUse = false;
	bool TT_isAxisInUse = false;
	bool rotateRightOne = false;
	bool rotateLeftOne = false;
	bool rotateRightTwo = false;
	bool rotateLeftTwo = false;
	bool rotateRightThree = false;
	bool rotateLeftThree = false;

	/*public IEnumerator RotateClockwise () {
		for(int x=1; x <= 360; x++){
			foreach(GameObject go in selectedOrbital){
				go.transform.rotation = Quaternion.AngleAxis(x, go.transform.position);
			}
			if(x==360){
				x=1;
			}
		}
	}*/
	

	
	
	


	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(childCounter);
		// max depth 3 = 258
		// max depth 4 = 1554
		// max depth 5 = 9330
		//groupedOne.transform.position = Vector3.zero;
		//groupedTwo.transform.position = Vector3.zero;
		//groupedThree.transform.position = Vector3.zero;
		


		if ((childCounter == 258 || childCounter == 1554 || childCounter == 9330) && childBuilding){
			
			levelOne = GameObject.FindGameObjectsWithTag("one");
			levelTwo = GameObject.FindGameObjectsWithTag("two");
			levelThree = GameObject.FindGameObjectsWithTag("three");
			//levelFour = GameObject.FindGameObjectsWithTag("four");
			//levelFive = GameObject.FindGameObjectsWithTag("five");
			//levelSix = GameObject.FindGameObjectsWithTag("six");
			masterArray[0] = levelOne;
			masterArray[1] = levelTwo;
			masterArray[2] = levelThree;
			//masterArray[3] = levelFour;
			//masterArray[4] = levelFive;
			//masterArray[5] = levelSix;

		 	childBuilding = false;

		 	foreach(GameObject go in levelOne){
		 		go.transform.DetachChildren();
		 		originalOne.Add(go.transform.localPosition);
		 		go.transform.parent = groupedOne.transform;
		 		rotateOne.Add(go.transform.rotation);
		 	}
		 	foreach(GameObject go in levelTwo){
		 		go.transform.DetachChildren();
		 		originalTwo.Add(go.transform.localPosition);
		 		go.transform.parent = groupedTwo.transform;
		 		rotateTwo.Add(go.transform.rotation);
		 	}
		 	foreach(GameObject go in levelThree){
		 		go.transform.DetachChildren();
		 		originalThree.Add(go.transform.localPosition);
		 		go.transform.parent = groupedThree.transform;
		 		rotateThree.Add(go.transform.rotation);
		 	}

		 	groupReset.Add(groupedOne.transform.rotation);
		 	groupReset.Add(groupedTwo.transform.rotation);
		 	groupReset.Add(groupedThree.transform.rotation);

		}



		if(childBuilding == false){

			//MAKE THREE ROTATEORBITALS
			//USE if SELECTEDORBITAL == ROTATEORBITAL# THEN DO THIS


			if(triggerCounter==0){
				groupedOne.transform.Rotate(new Vector3(Input.GetAxis("L_XAxis_0"),Input.GetAxis("L_YAxis_0"),Input.GetAxis("R_XAxis_0")) * Time.deltaTime * spinSpeed);
			}
			if(triggerCounter==1){
				groupedTwo.transform.Rotate(new Vector3(Input.GetAxis("L_XAxis_0"),Input.GetAxis("L_YAxis_0"),Input.GetAxis("R_XAxis_0")) * Time.deltaTime * spinSpeed);
			}
			if(triggerCounter==2){
				groupedThree.transform.Rotate(new Vector3(Input.GetAxis("L_XAxis_0"),Input.GetAxis("L_YAxis_0"),Input.GetAxis("R_XAxis_0")) * Time.deltaTime * spinSpeed);
			}

				if(rotateRightOne==true){
					foreach(GameObject go in levelOne){
						//go.transform.rotation = Quaternion.AngleAxis(x, go.transform.position);
						go.transform.Rotate(go.transform.localPosition * Time.deltaTime * spinSpeed);	
					}		
				}
				if(rotateRightTwo==true){
					foreach(GameObject go in levelTwo){
						//go.transform.rotation = Quaternion.AngleAxis(x, go.transform.position);
						go.transform.Rotate(go.transform.localPosition * Time.deltaTime * spinSpeed);
					}
				}
				if(rotateRightThree==true){
					foreach(GameObject go in levelThree){
						//go.transform.rotation = Quaternion.AngleAxis(x, go.transform.position);
						go.transform.Rotate(go.transform.localPosition * Time.deltaTime * spinSpeed);
					}
				}
			
		
				if(rotateLeftOne==true){
					foreach(GameObject go in levelOne){
						//go.transform.rotation = Quaternion.AngleAxis(x, go.transform.position);
						go.transform.Rotate(go.transform.localPosition * Time.deltaTime * -spinSpeed);	
					}		
				}
				if(rotateLeftTwo){
					foreach(GameObject go in levelTwo){
						//go.transform.rotation = Quaternion.AngleAxis(x, go.transform.position);
						go.transform.Rotate(go.transform.localPosition * Time.deltaTime * -spinSpeed);
					}
				}
				if(rotateLeftThree){
					foreach(GameObject go in levelThree){
						//go.transform.rotation = Quaternion.AngleAxis(x, go.transform.position);
						go.transform.Rotate(go.transform.localPosition * Time.deltaTime * -spinSpeed);
					}
				}
			


			if (Input.GetButtonDown("A")){

				foreach(GameObject go in selectedOrbital){
					go.transform.localPosition = go.transform.localPosition - go.transform.localPosition.normalized; 
				}
			}


			if (Input.GetButtonDown("B")){
				
				foreach(GameObject go in selectedOrbital){
					go.transform.localPosition = go.transform.localPosition + go.transform.localPosition.normalized; 
				}
				//incremental explosion
				// needs to have a MAX DISTANCE (use if (go.magnitude < ###))
			}




			if (Input.GetButtonDown("Y")){
				Debug.Log("Y");
				if(triggerCounter==0){
						rotateRightOne = false;
						rotateLeftOne = false;
						for(int x=0; x < selectedOrbital.Length; x++){
							GameObject go = selectedOrbital[x];
							go.transform.rotation = rotateOne[x];
						}
						
					}
					if(triggerCounter==1){
						rotateRightTwo=false;
						rotateLeftTwo=false;
						for(int x=0; x < selectedOrbital.Length; x++){
							GameObject go = selectedOrbital[x];
							go.transform.rotation = rotateTwo[x];
						}
					}
					if(triggerCounter==2){
						rotateRightThree=false;
						rotateLeftThree=false;
						for(int x=0; x < selectedOrbital.Length; x++){
							GameObject go = selectedOrbital[x];
							go.transform.rotation = rotateThree[x];
						}
					}
				//reset rotate
			}


			if (Input.GetButtonDown("X")){
				//position reset, keeps rotation 
				if(triggerCounter==0){
					for(int x=0; x < selectedOrbital.Length; x++){
						GameObject go = selectedOrbital[x];
						go.transform.localPosition = originalOne[x];
					}
				}
				if(triggerCounter==1){
					for(int x=0; x < selectedOrbital.Length; x++){
						GameObject go = selectedOrbital[x];
						go.transform.localPosition = originalTwo[x];
					}
				}
				if(triggerCounter==2){
					for(int x=0; x < selectedOrbital.Length; x++){
						GameObject go = selectedOrbital[x];
						go.transform.localPosition = originalThree[x];
					}
				}
			}

			if (Input.GetButtonDown("Back")){
				Debug.Log("Back");
				// total reset, stops rotation
			}
			if (Input.GetButtonDown("LeftStick") && !Input.GetButton("RightStick")){
				Debug.Log("LeftStick");
				//?????
				//changes material?
			}
			if (Input.GetButtonDown("RightStick") && !Input.GetButton("LeftStick")){
				Debug.Log("RightStick");
				if(triggerCounter==0){
					groupedOne.transform.rotation = groupReset[0];
				}
				if(triggerCounter == 1){
					groupedTwo.transform.rotation = groupReset[1];
				}
				if(triggerCounter == 2){
					groupedThree.transform.rotation = groupReset[2];
				}
			}
			if (Input.GetButtonDown("RightStick")){
				if (Input.GetButtonDown("LeftStick")){
				Debug.Log("Both Sticks");
				}
				//?????
				//reset material? 
			}
			if (Input.GetButtonDown("Start")){
				Debug.Log("Start");
				//???????
				// brings up scrollable UI menu with information about fractal
			}

			if (Input.GetButtonDown("LeftShoulder") && !Input.GetButton("RightShoulder")){
				Debug.Log("Left Shoulder");	
				//groupedThree.transform.Rotate(new Vector3(45,45,45) * Time.deltaTime);
				if(selectedOrbital==levelOne){
					rotateLeftOne=true;
					rotateRightOne=false;
				}
				if(selectedOrbital==levelTwo){
					rotateLeftTwo=true;
					rotateRightTwo=false;
				}
				if(selectedOrbital==levelThree){
					rotateLeftThree=true;
					rotateRightThree=false;
				}
				
				

			}

			if (Input.GetButtonDown("RightShoulder") && !Input.GetButton("LeftShoulder")){
				Debug.Log("Right Shoulder");	
				//groupedTwo.transform.Rotate(new Vector3(45,45,45) * Time.deltaTime);
				if(selectedOrbital==levelOne){
					rotateRightOne=true;
					rotateLeftOne=false;
				}
				if(selectedOrbital==levelTwo){
					rotateRightTwo=true;
					rotateLeftTwo=false;
				}
				if(selectedOrbital==levelThree){
					rotateRightThree=true;
					rotateLeftThree=false;
				}
			}

			if (Input.GetButtonDown("RightShoulder")){
				if (Input.GetButtonDown("LeftShoulder")){
					Debug.Log("Both Shoulders");
					
					
				}
			}
			



			if( Input.GetAxisRaw("TriggersR_0") == 1 && Input.GetAxisRaw("TriggersL_0") == 0){
	         	if(RT_isAxisInUse == false){
	             	Debug.Log("Right Trigger");
	            	 RT_isAxisInUse = true;
	             //rotate through array of gameobjects 
	             //selected objects should glow 
	             // triggerCounter replaced masterArray.length
	             // triggerCounter needs to become a dynamic variable if you are going to be able to change the number of active levels/generations
	             	triggerCounter++;

	             	if(triggerCounter==3){
	             		triggerCounter=0;
	             	}

	             	selectedOrbital = masterArray[triggerCounter];
	            }
	    	}

	     	if( Input.GetAxisRaw("TriggersR_0") == 0){
	         	RT_isAxisInUse = false;
	     	} 


	     	if( Input.GetAxisRaw("TriggersL_0") == 1 && Input.GetAxisRaw("TriggersR_0") == 0){
	         	if(LT_isAxisInUse == false){
	             	Debug.Log("Left Trigger");
	             	LT_isAxisInUse = true;
	             //rotate through array of gameobjects 
	             //selected objects should glow 
	             	triggerCounter--;

	             	if(triggerCounter== -1){
	             		triggerCounter=2;
	             	}

	             	selectedOrbital = masterArray[triggerCounter];
	         	}
	    	}
	     	if( Input.GetAxisRaw("TriggersL_0") == 0){
	         	LT_isAxisInUse = false;
	     	}  



	     	if( Input.GetAxisRaw("TriggersL_0") == 1 && Input.GetAxisRaw("TriggersR_0") == 1){
	         	if(TT_isAxisInUse == false){
	             	Debug.Log("Both Triggers");
	             	TT_isAxisInUse = true;
	             //deselect array
	             	selectedOrbital = null; 
	         	}
	    	}
	     	if( Input.GetAxisRaw("TriggersL_0") == 0 && Input.GetAxisRaw("TriggersR_0") == 0){
	         	TT_isAxisInUse = false;
	     	}  
	    }
	}
}
