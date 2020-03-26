using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PPText : MonoBehaviour {
	public string name;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = PlayerPrefs.GetInt (name)+"";
	
	}
}
