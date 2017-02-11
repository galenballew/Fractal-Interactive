using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class level_Directory : MonoBehaviour {

	public List<GameObject> depthOne;
	public List<GameObject> depthTwo;
	public List<GameObject> depthThree;
	public List<GameObject> depthFour;
	public List<GameObject> depthFive;


	public void AddToList(GameObject child, int childDepth) {

			if(childDepth == 1)
			{
				depthOne.Add(child); 
			}
			else if (childDepth == 2) {
				depthTwo.Add(child); 
			}
			else if (childDepth == 3) {
				depthThree.Add(child); 
			}
			else if (childDepth == 4) {
				depthFour.Add(child); 
			}
			else if (childDepth == 5) {
				depthFive.Add(child); 
			}

	}

	// Use this for initialization
	void Start () {

		foreach(var go in depthOne) {
         Debug.Log(go.name);
     	}
     	foreach(var go in depthTwo) {
         Debug.Log(go.name);
     	}
     	foreach(var go in depthThree) {
         Debug.Log(go.name);
     	}
     	foreach(var go in depthFour) {
         Debug.Log(go.name);
     	}
     	foreach(var go in depthFive) {
         Debug.Log(go.name);
     	}
	
	}
	
	// Update is called once per frame
	void Update () {
	

	//enter the controls here
	}
}
