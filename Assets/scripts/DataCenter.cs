using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataCenter : MonoBehaviour
{
	public static string name = getName();
	public static int level=getLevel();
	public static string[] chengguoji = getchengguoji();


	static string getName() {
		string name="PianoHero";
		if (!File.Exists ("user.txt")) {
			return name;
		} else {
			//读原来的最高分数
			StreamReader sr = File.OpenText("user.txt");
			string line;
			int index = 0;
			while (((line = sr.ReadLine ()) != null) && (line != "")) {
				index++;
				if (index == 1) {
					name = line;
				}
			}
			sr.Close ();
			return name;
		}

	}

	static int getLevel() {
		int re = 0;
		if (!File.Exists ( "user.txt")) {
			return re;
		} else {
			//读原来的最高分数
			StreamReader sr = File.OpenText("user.txt");
			string line;
			int index = 0;
			while (((line = sr.ReadLine ()) != null) && (line != "")) {
				index++;
				if (index == 2) {
					int line2 = int.Parse(line);
					re = line2;
				}
			}
			sr.Close ();
			return re;
		}

	}

	static string[] getchengguoji() {
		if (!File.Exists ( "user.txt")) {
			return new string[0];
		} else {
			ArrayList result = new ArrayList();
			//读原来的最高分数
			StreamReader sr = File.OpenText("user.txt");
			string line;
			int index = 0;
			while (((line = sr.ReadLine ()) != null) && (line != "")) {
				index++;
				if (index > 2) {
					result.Add (line);
				}
			}
			sr.Close ();
			return (string[])result.ToArray(typeof( string));
		}

	}

	public static void WriteSong(string name,int score)
    {

		if (!File.Exists (name + ".txt")) {
			StreamWriter sw = File.CreateText (name + ".txt");
			//歌名
			sw.WriteLine (name);
			//得分
			sw.WriteLine (score);
			//最高得分
			sw.WriteLine (score);
			sw.Close ();
		} else {
			//读原来的最高分数
			StreamReader sr = File.OpenText(name+".txt");
			int index=0;
			string line;
			int hscore=0;
			while (((line = sr.ReadLine ()) != null) && (line != "")) {
				index++;
				if (index == 3) {
					int line2 = int.Parse(line);
					if (line2 > score)
						hscore = line2;
					else
						hscore = score;
				}
			}
			sr.Close ();

			//写入新的
			StreamWriter sw = File.CreateText (name + ".txt");
			//歌名
			sw.WriteLine (name);
			//得分
			sw.WriteLine (score);
			//最高得分
			sw.WriteLine (hscore);
			sw.Close ();
		}
    }

	public static int GetHScore(string name){

		//读原来的最高分数
		StreamReader sr = File.OpenText(name+".txt");
		int index=0;
		string line;
		int hscore=0;
		while (((line = sr.ReadLine ()) != null) && (line != "")) {
			index++;
			if (index == 3) {
				hscore = int.Parse(line);
			}
		}
		sr.Close ();
		return hscore;
	}

	public static void WriteUserName(string myname){
		StreamWriter sw = File.CreateText (  "user.txt");
		name = myname;
		sw.WriteLine (myname);
		sw.WriteLine (level);
		for (int i = 0; i < chengguoji.Length; i++) {
			sw.WriteLine (chengguoji [i]);
		}
	}

	public static void WriteUserLevel(int mylevel){
		StreamWriter sw = File.CreateText (  "user.txt");
		level = mylevel;
		sw.WriteLine (name);
		sw.WriteLine (mylevel);
		for (int i = 0; i < chengguoji.Length; i++) {
			sw.WriteLine (chengguoji [i]);
		}
	}

	public static void WriteUserChengguoji(){
		StreamWriter sw = File.CreateText (  "user.txt");
		sw.WriteLine (name);
		sw.WriteLine (level);
		for (int i = 0; i < chengguoji.Length; i++) {
			sw.WriteLine (chengguoji [i]);
		}
	}
}
