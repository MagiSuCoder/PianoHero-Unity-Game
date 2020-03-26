using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Songdata{
	public string songname;
	public int score;
	public int level;
	public int bestscore;

	public Songdata(string songname){
		this.songname = songname;
		this.score = 0;
		this.bestscore = 0;
	}

}
[System.Serializable]
public class User{
	public string username;
	public int level;
	public List<Songdata> playList;
}
[System.Serializable]
public class Setting{
	public int color;
}


public class Datacontroller : MonoBehaviour {
	public static Datacontroller instance;
	public Songdata currentSong;
	public User currentUser;
	public static int step = 50;
	public string username;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (transform.gameObject);
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		if (!File.Exists (Application.persistentDataPath + "/userdata.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/userdata.dat");
			User user = new User ();
			user.username = "Mary";
			user.level = 0;
			user.playList = new List<Songdata> (); 
			bf.Serialize (file, user);
			file.Close ();
		}

		BinaryFormatter bf2 = new BinaryFormatter ();
		FileStream file2 = File.Open (Application.persistentDataPath + "/userdata.dat", FileMode.Open);
		User userdata = (User)bf2.Deserialize (file2);
		file2.Close ();
		Datacontroller.instance.username = userdata.username;
		Datacontroller.instance.currentUser = userdata;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int SaveAndGetHScore(){
		int bscore = Datacontroller.instance.currentSong.score;
		//讀出來
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/userdata.dat", FileMode.Open);
		User userdata = (User)bf.Deserialize (file);
		file.Close ();
		bool matched = false;
		bool found = false;
		foreach(Songdata song in  userdata.playList) {
			if (Datacontroller.instance.currentSong.songname == song.songname) {
				
			if (Datacontroller.instance.currentSong.score >= song.bestscore) {
					userdata.playList.RemoveAt (userdata.playList.IndexOf( song));
					song.bestscore = Datacontroller.instance.currentSong.score;
					userdata.playList.Insert (0, song);
					matched = true;
				} else {
					bscore = song.bestscore;
				}
				found = true;
				break;
			}
		}
		if (!found) {
			BinaryFormatter bf2 = new BinaryFormatter ();
			FileStream file2 = File.Create (Application.persistentDataPath + "/userdata.dat");
			userdata.playList.Add (Datacontroller.instance.currentSong);
			bf2.Serialize (file2, userdata);
			file2.Close ();
		}
		else if (found&&matched) {
			BinaryFormatter bf2 = new BinaryFormatter ();
			FileStream file2 = File.Create (Application.persistentDataPath + "/userdata.dat");
			bf2.Serialize (file2, userdata);
			file2.Close ();
		}
		//Datacontroller.instance.currentSong.bestscore = bscore;
		return bscore;
	}

	public void SaveUsername(string uname){
		//讀出來userdata
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/userdata.dat", FileMode.Open);
		User userdata = (User)bf.Deserialize (file);
		file.Close ();
		//return userdata.playList;
		//移花接木
		userdata.username = uname;
		//写回去userdata
		BinaryFormatter bf2 = new BinaryFormatter ();
		FileStream file2 = File.Create (Application.persistentDataPath + "/userdata.dat");
		bf2.Serialize (file2, userdata);
		file2.Close ();
	}
	public static void Save(){
		BinaryFormatter bf2 = new BinaryFormatter ();
		FileStream file2 = File.Create (Application.persistentDataPath + "/userdata.dat");
		bf2.Serialize (file2, Datacontroller.instance.currentUser);
		file2.Close ();
	}

	void OnDestory(){
		Save ();
	}
}
