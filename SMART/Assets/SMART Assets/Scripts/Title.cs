using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
	//get gui texture
	public Texture title;
	public Texture titleLight;

	float alpha=1.0f;

	public float fadeOutStart=2.5f;

	float timer;
	public float lightMoveSpeed=200f;
	public float startTimeLight=0f;
	public float endTimeLight=3f;
	public float move = -300f;

	void OnGUI(){
		//inc timer
		timer += Time.deltaTime;
		move += lightMoveSpeed * Time.deltaTime;
		//start fading out
		if (timer > fadeOutStart && alpha > 0) {
			alpha -= 0.01f;
		}
		if (alpha < 0) {
			alpha = 0;
		}
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = 0;
		//draw title image
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), title,ScaleMode.StretchToFill);
		if (timer > startTimeLight && timer<endTimeLight) {
			GUI.DrawTexture (new Rect (move, 0, Screen.width, Screen.height), titleLight, ScaleMode.StretchToFill);
		}

	}
}