using UnityEngine;
using System.Collections;

public class HideOthers : MonoBehaviour {
	public GameObject []others;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void Hide()
	{
				for (int i=0; i<others.Length; i++)
						others [i].transform.localScale = new Vector3 (0f, 0f, 0f);
		}
}
