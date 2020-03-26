using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Texture2D texture = new Texture2D(100, 100);
		GetComponent<Renderer>().material.mainTexture = texture;

		for (int y = 0; y < texture.height; y++)
		{
			for (int x = 0; x < texture.width; x++)
			{
				Color color = ((x & y) != 0 ? Color.white : Color.red);
				texture.SetPixel(x, y, color);
			}
		}
		texture.Apply();
		Image renderer = GetComponent<Image>();
		//renderer.material.mainTexture = texture;
		renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
