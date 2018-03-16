using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour {

	private Transform camTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	//road = 0
	//bg = 1
	public int type;
	public float backgroundSize;

	private void Start(){
		camTransform = Camera.main.transform;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			layers [i] = transform.GetChild (i);
		}
		leftIndex = 0;
		rightIndex = layers.Length-1;
	}

	private void scrollLeft(){
		int lastRight = rightIndex;
		layers[rightIndex].position = Vector3.right * (layers [leftIndex].position.x - backgroundSize);
		if(type == 0){
			layers[rightIndex].position = layers[rightIndex].position - new Vector3(0, 8, 0);
		}
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) {
			rightIndex = layers.Length - 1;
		}
	}

	private void scrollRight(){
		int lastLeft = leftIndex;
		layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
		if(type == 0){
			layers[leftIndex].position = layers[leftIndex].position - new Vector3(0, 8, 0);
		}
	
		rightIndex = leftIndex;
		leftIndex++;
		if(leftIndex == layers.Length){
			leftIndex = 0;
		}
	}

	private void Update(){
		if(camTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)){
			scrollLeft();
		}

		if(camTransform.position.x > (layers[rightIndex].transform.position.x - viewZone)){
			scrollRight();
		}
	}

}
