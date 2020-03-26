using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note2 : MonoBehaviour {
	private Rigidbody2D rb;
	public  float speed=2;
	// Use this for initialization
	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}
	void Start () {
		rb.velocity = new Vector2 (0, -speed);

	}

	// Update is called once per frame
	void Update () {

	}
}
