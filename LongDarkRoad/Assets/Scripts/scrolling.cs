using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour {

	private Transform camTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;


	public float backgroundSize;

	private void start(){
		camTransform = Camera.main.transform;
		layers = new Transform[camTransform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			layers [i] = transform.GetChild (i);
		}
		leftIndex = 0;
		rightIndex = layers.Length-1;
	}

	private void scrollLeft(){
		int lastRight = rightIndex;
		layers [rightIndex].position = Vector3.right * (layers [leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) {
			rightIndex = layers.Length - 1;
		}
	}

	private void scrollRight(){
	}

}
