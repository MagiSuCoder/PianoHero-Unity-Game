using UnityEngine;
using System.Collections;

public class note : MonoBehaviour {
	private Rigidbody2D rb;
	public  float speed;
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
