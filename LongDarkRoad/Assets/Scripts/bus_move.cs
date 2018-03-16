using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bus_move : MonoBehaviour {
	public float speed = 3.0f; 
	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = startPos;
		v.x -=  (Time.time * speed);
		transform.position = v;
	}
}
