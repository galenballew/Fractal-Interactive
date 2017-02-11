using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Fractal : MonoBehaviour {

	public static Vector3[] childDirections = {
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back,	
		Vector3.down,
	};

	public static Quaternion[] childOrientations = {
		Quaternion.identity,
		Quaternion.Euler(0f, 0f, -90f),
		Quaternion.Euler(0f, 0f, 90f),
		Quaternion.Euler(90f, 0f, 0f),
		Quaternion.Euler(-90f, 0f, 0f),
		Quaternion.identity,
	};

	public Mesh mesh;
	public Material material;
	public int maxDepth;
	public float childScale;

	public int depth;
	public int count; 


	public void Start () {
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		gameObject.AddComponent<MeshRenderer>().material = material;
	
		if (depth < maxDepth) {
			StartCoroutine(CreateChildren());
		}
	}

	public IEnumerator CreateChildren () {
		


		for (int i = 0; i < childDirections.Length; i++) {
			yield return new WaitForSeconds(0.5f);
			GameObject child = new GameObject("FractalChild");
			child.AddComponent<Fractal>().Initialize(this, i);
			if (depth == 0){
				child.tag = "one";
			}
			else if (depth == 1) {
				child.tag = "two";
			} 
			else if (depth == 2){
				child.tag = "three";
			}
			else if (depth == 3){
				child.tag = "four";
			}
			else if (depth == 4){
				child.tag = "five";
			}
			else if (depth == 5){
				child.tag = "six";
			}
			else if (depth == 6){
				child.tag = "seven";
			}
		}
		


	}

	public void Initialize (Fractal parent, int childIndex) {
		mesh = parent.mesh;
		material = parent.material;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		childScale = parent.childScale;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
		transform.localRotation = childOrientations[childIndex];
		GameObject countObject = GameObject.Find("Controls"); 
		countObject.GetComponent<controls>().childCounter++;

	}
}