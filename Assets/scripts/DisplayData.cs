using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayData : MonoBehaviour {
    [SerializeField]
    GameObject disBoard;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
    public void Upda()
    {
        string va="";
        for (int i = 0; i < GetComponent<DataCenter>().n; i++)
            va = va + "Game: " + GetComponent<DataCenter>().names[i] + "\n" + "Scole: " + GetComponent<DataCenter>().highestScole[i] + "\n" + "Level: " + GetComponent<DataCenter>().level[i] + "\n" + "Rank: " + GetComponent<DataCenter>().score[i] + "\n";
        disBoard.GetComponent<UnityEngine.UI.Text>().text = va;
    }
    */
}
