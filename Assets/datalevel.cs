using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class datalevel : MonoBehaviour {
	private Text leveltext;
	// Use this for initialization
	void Start () {
		leveltext = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		leveltext.text = "等级："+ Datacontroller.instance.currentUser.level.ToString();
	}
}
