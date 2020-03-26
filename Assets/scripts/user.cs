using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user : MonoBehaviour {

	public GameObject panel;
	public GameObject qbutton;
	public Text displayname;
	public InputField inputName;

	private string userName;
	public Text me;
	AsyncOperation async;
	// Use this for initialization
	void Start () {
		me.text = Datacontroller.instance.username;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Popup(){
		panel.SetActive (true);
		qbutton.SetActive (true);
	}

	public void Popout(){
		panel.SetActive (false);
		qbutton.SetActive (false);

	}

	IEnumerator SaveUName(string uname){
		
		yield return async;
	}
	public void SaveAndPopout(){
		
		panel.SetActive (false);
		qbutton.SetActive (false);
		me.text = inputName.text;
		Datacontroller.instance.SaveUsername (inputName.text);
	}
}
