using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class border : MonoBehaviour {

	public static string songname;

	public Text scoreText;
	public Text levelText;
	public Text hScoreText;
	private int count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Finish") {
			count+=Datacontroller.step;
			if (Datacontroller.instance.currentSong.score / count< 0.3) {
				
				Datacontroller.instance.currentSong.level = 1;
			}
			else if (Datacontroller.instance.currentSong.score  / count< 0.7)
				Datacontroller.instance.currentSong.level  = 2;
			else
				Datacontroller.instance.currentSong.level  = 3;

			//DataCenter.WriteSong (songname,score);
			//int hscore = DataCenter.GetHScore (songname);
			Datacontroller.instance.currentUser.level+=Datacontroller.instance.currentSong.level;
			int hscore = Datacontroller.instance.SaveAndGetHScore();

			scoreText.gameObject.SetActive (true);
			levelText.gameObject.SetActive (true);
			hScoreText.gameObject.SetActive (true);

			scoreText.text = "游戏得分："+Datacontroller.instance.currentSong.score.ToString();
			levelText.text = " 等级：" + Datacontroller.instance.currentSong.level.ToString ();
			hScoreText.text = "最高得分：" + hscore.ToString ();


		}
		Destroy (coll.gameObject);
		count+=Datacontroller.step;
	}



}
