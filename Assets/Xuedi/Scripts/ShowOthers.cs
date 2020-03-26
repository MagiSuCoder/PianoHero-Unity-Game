using UnityEngine;
using System.Collections;

public class ShowOthers : MonoBehaviour {
	public GameObject []others;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Show()
	{
		for(int i=0;i<others.Length;i++)
			others[i].transform.localScale=new Vector3(1f,1f,1f);
		}
}
