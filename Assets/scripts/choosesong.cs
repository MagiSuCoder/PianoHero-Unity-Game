using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class choosesong : MonoBehaviour {
	
	public GameObject song;
	public GameObject songmenu;
	public GameObject bottommenu;


	// Use this for initialization
	void Start () {
		//mysong = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void chooseSong(){
		
		Datacontroller.instance.currentSong = new Songdata (song.name);
		song = Instantiate (song, new Vector3 (0, -67, 0), Quaternion.identity);
		song.SetActive (true);


	}

	public void exitMenu(){
		songmenu.SetActive (false);
		bottommenu.SetActive (false);
	}

}
