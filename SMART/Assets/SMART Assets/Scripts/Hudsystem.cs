using UnityEngine;
using System.Collections;

public class Hudsystem : MonoBehaviour {
	public GameObject Hud1;
	public GameObject Hud2;
	public GameObject Hud3;
	public GameObject Hud4;

	private int[] hudtable = new int[4];
	public int score;

	public Texture[] numTexts = new Texture[10];

	// Use this for initalization
	void Start () {
		int discore = score;
		for (int i = 3; i >= 0; i--) {
			hudtable[i] = discore % 10;
			discore /= 10;
		}
	}
	//this function is called in update, changes the texture accordingly
	void changeText(int v, GameObject plane) {
		plane.renderer.material.mainTexture = numTexts[v];
		}

	//changes the hudtable at pos to newval
	void changeNum(int newVal, int pos) {
		hudtable [pos] = newVal;
		}

	//changes score to newScore
	void changeScore(int newScore) {
				score = newScore;
		}

	// Update is called once per frame
	void Update () {
		//updates score somehow
		int discore = score;
		for (int i = 3; i >= 0; i--) {
			hudtable[i] = discore % 10;
			discore /= 10;
		}

		//changes textures accordingly
		for (int i = 0; i < hudtable.Length; i++)
		{
			int value = hudtable[i];
			if (i == 0)
			{
				changeText (value, Hud1);
			}
			if (i == 1)
			{
				changeText (value, Hud2);
			}
			if (i == 2)
			{
				changeText (value, Hud3);
			}
			if (i == 3)
			{
				changeText (value, Hud4);
			}
		}
	}
}
