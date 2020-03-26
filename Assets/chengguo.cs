using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class chengguo : MonoBehaviour {


	public GameObject songItem;
	public GameObject parent;

	public GameObject songmenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void readSong(){
		songmenu.SetActive (true);
		List<Songdata> songList = Datacontroller.instance.currentUser.playList;

		foreach (Songdata song in songList) {
			songItem.GetComponentsInChildren<Text> () [0].text = "歌名"+song.songname;
			songItem.GetComponentsInChildren<Text> () [1].text = "最高得分"+song.score.ToString();
			songItem.GetComponentsInChildren<Text> () [2].text = "等级"+song.level.ToString();
			Instantiate (songItem, parent.transform);
		}

	}
}
