using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topbox : MonoBehaviour {

	public GameObject[] box;

	// Use this for initialization
	void Start () {
		box[0] = Instantiate (box[0], transform.position, Quaternion.identity);
		box[1] = Instantiate (box[1], new Vector3(transform.position.x,transform.position.y+1.0f), Quaternion.identity);
		box[2] = Instantiate (box[2], new Vector3(transform.position.x,transform.position.y+2.0f), Quaternion.identity);
		box[0].SetActive (false);
		box[1].SetActive (false);
		box[2].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		//Instantiate (pinpu, new Vector3 (transform.position.x, transform.position.y + 2.2f, transform.position.z), Quaternion.identity);
		switch (col.gameObject.tag) {
		case "Note3":
			box [2].SetActive (true);
			box [1].SetActive (true);
			box [0].SetActive (true);
			break;
		case "Note2":
			box [1].SetActive (true);
			box [0].SetActive (true);
			break;
		case "Note":
			box [0].SetActive (true);
			break;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		box[0].SetActive (false);
		box[1].SetActive (false);
		box[2].SetActive (false);
	}
}
