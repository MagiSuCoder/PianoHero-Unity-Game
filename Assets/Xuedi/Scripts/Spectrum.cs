using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour {
    float [] spectrum;
    public GameObject cube;
	//public SpriteRenderer sr;
    GameObject[] cubes;
    public const int numbersOfCube=1024;
    public float ridus;
    public float secondsPerLerp=0.2f;
    public float height = 20f;
    float seconds= 0f;
	AudioSource au;
    float[] y;
	// Use this for initialization
	void Start () {
		au = GetComponent<AudioSource> ();
        height = numbersOfCube *6;
        seconds = secondsPerLerp;
        spectrum = new float[numbersOfCube];
        cubes = new GameObject[numbersOfCube];
		//colors = new Color[sr.sprite.texture.width*sr.sprite.texture.height];
        y= new float[numbersOfCube];
        ridus = numbersOfCube / (2 * Mathf.PI);
        for (int i = 0; i < numbersOfCube; i++)
        {
			cubes[i] = Instantiate(cube,transform.position, transform.rotation);
            //line
            //cubes[i].transform.Translate(new Vector3((i-numbersOfCube/2)*0.5f,0f,0f));


            //circle
            float degree = i * 2 * Mathf.PI / numbersOfCube;
            cubes[i].transform.Translate(new Vector3(ridus*Mathf.Cos(degree),0f , ridus * Mathf.Sin(degree)));

        }


	}
	
	// Update is called once per frame
	void Update () {
        //spectrum = AudioListener.GetSpectrumData(64,0,FFTWindow.Hamming);
        //Debug.Log(cubes[127].GetComponent<Transform>().localScale.y + "  "+spectrum[127]);
        //Debug.Log(Mathf.Lerp(cubes[127].GetComponent<Transform>().localScale.y, spectrum[127], 0.5f)*20);
		au = gameManager.doremi;
        if (seconds >= secondsPerLerp)
        {
            AudioListener.GetSpectrumData(spectrum, 0,FFTWindow.Hamming);
            seconds = 0f;
            for(int i=0;i<numbersOfCube;i++)
                y[i] = cubes[i].GetComponent<Transform>().localScale.y;
        }
        seconds += Time.deltaTime;
        for (int i=0;i<numbersOfCube;i++)
        {
            
            float nextY =  Mathf.Lerp(y[i], spectrum[i] * height, seconds/secondsPerLerp);
            cubes[i].GetComponent<Transform>().localScale=new Vector3(1f,nextY, 1f);
        }


		//处理图片
		/*for (int i = 0; i < sr.sprite.texture.width; i++) {
			for (int j = 0; j < sr.sprite.texture.height; j++) {
				var h  = cubes [(j * sr.sprite.texture.height + i)%numbersOfCube].transform.localScale.y;
				var y = ((h) / (1 + h));
				var color = sr.sprite.texture.GetPixel (i, j);
				//colors [j * sr.sprite.texture.height + i] = NormalBlend(new Color(y,y,y),color);
				colors [j * sr.sprite.texture.height + i]=new Color(1-color.r,1-color.g,1-color.b);
			}
		}

		sr.sprite.texture.SetPixels (colors);
		sr.sprite.texture.Apply();*/
    }

	/*Color NormalBlend(Color dest,Color src){
		float srcAlpha = src.a;
		float destAlpha = (1 - srcAlpha) * dest.a;
		Color destlayer = dest * destAlpha;
		Color srclayer = src * srcAlpha;
		return destlayer + srclayer;
	}*/

}
