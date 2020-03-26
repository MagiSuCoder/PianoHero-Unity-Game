using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {
	SpriteRenderer sr;
	public KeyCode key;
	public bool createMode;
	public GameObject n;
	public GameObject pinpu;
	public GameObject[] fires ;
	AudioSource au;
	bool active=false;
	GameObject note,gm;
	Color old;
	int leap = 0;
	bool isPressed = false;

	void Awake () {
		sr = GetComponent<SpriteRenderer>();
		au = GetComponent<AudioSource> ();
		fires[0] = Instantiate (fires [0], new Vector3(transform.position.x,transform.position.y+transform.localScale.y/2.0f,0), Quaternion.identity);
		fires[1] = Instantiate (fires [1], transform.position, Quaternion.identity);
		fires [0].SetActive (false);
		fires [1].SetActive (false);
	}
	// Use this for initialization
	void Start () {
		old = sr.color;
		gm = GameObject.Find ("gameManager");
	}


	// Update is called once per frame
	void Update () {
		if (createMode) {
			if (Input.GetKeyDown (key)) {
				Instantiate (n, transform.position, Quaternion.identity);
			} 
		}else {
			if (Input.GetKeyDown (key)) {
				
				StartCoroutine (Pressed ());
			}

			if (Input.GetKeyDown (key) && active) {
				Destroy (note);
				Addscore ();
				active = false;
			}
		
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (isPressed) {
			//border.score += border.step;
			Datacontroller.instance.currentSong.score+=Datacontroller.step;
		}

		active = true;
		//Instantiate (pinpu, new Vector3 (transform.position.x, transform.position.y + 2.2f, transform.position.z), Quaternion.identity);
		if (col.gameObject.tag.Contains("Note"))
			note = col.gameObject;
	}
	void OnTriggerExit2D(Collider2D col){
		active = false;
	}
	IEnumerator Pressed(){
		isPressed = true;
		old = sr.color;
		sr.color = new Color (0, 0, 0);
		au.Play ();
		if(!active)
			fires [0].SetActive (true);
		else
			fires [1].SetActive (true);
		yield return new WaitForSeconds (0.2f);
		sr.color = new Color (255, 255, 255);
		fires [0].SetActive (false);
		fires [1].SetActive (false);
		gameManager.doremi = au;

		yield return new WaitForSeconds (0.8f);
		isPressed = false;
	}
	void Addscore(){
		PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+gm.GetComponent<gameManager>().GetScore());

	}
		
}
