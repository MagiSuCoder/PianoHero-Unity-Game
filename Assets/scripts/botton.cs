using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class botton : MonoBehaviour {

	public GameObject tanchuang;
	public AudioSource gequ1;
	public AudioSource gequ2;
	public AudioSource gequ3;

	public GameObject datacontroller;

	public void inTeachmode(){
		
		SceneManager.LoadScene (1);
		SceneManager.MoveGameObjectToScene(datacontroller,SceneManager.GetActiveScene());
	}
	public void inArtmode(){
//		SceneManager.MoveGameObjectToScene(datacontroller,SceneManager.GetSceneByBuildIndex(2));
		SceneManager.LoadScene (2);
	}
	public void inImagemode(){
//		SceneManager.MoveGameObjectToScene(datacontroller,SceneManager.GetSceneByBuildIndex(3));
		SceneManager.LoadScene (3);
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
