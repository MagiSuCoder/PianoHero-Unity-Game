using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class gameManager : MonoBehaviour {
	

	int multiplier=1;
	int  streak=0;

	public GameObject gameOverText;
	public GameObject restartText;
	private bool gameOver;
	private bool restart;
	private AudioSource sound;
	public static AudioSource doremi; 
	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
		gameOver = false;
		restart = false;
		doremi = GetComponent<AudioSource> ();
	}
	public void inRestart(){
		SceneManager.LoadScene (1);


	}
	// Update is called once per frame
	void Update () {
		if ((sound.isVirtual==true)||(Input.GetKeyDown (KeyCode.Q))){
			GameOver();
		}
		if(restart) {
			if (Input.GetKeyDown (KeyCode.R))
				SceneManager.LoadScene(1);
			restart=false;
		}
	}



	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}

	public int GetScore(){
		return 100 * multiplier;
	}



	public void GameOver(){
		gameOver = true;
		gameOverText.SetActive (true);
		restartText.SetActive (true);
		restart = true;
	}

}