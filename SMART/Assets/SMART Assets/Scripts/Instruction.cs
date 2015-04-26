using UnityEngine;
using System.Collections;

public class Instruction : MonoBehaviour {

	public Texture instruction;
	
	float alpha,timer = 0f;
	public float start = 4f;
	public float end = 14f;

	public float px; public float py;
	public float sx; public float sy;
	
	void Start() {
		px *= (float)Screen.width; py *= (float)Screen.height;
		sx *= (float)Screen.width; sy *= (float)Screen.height;
	}

	void OnGUI(){
		timer += Time.deltaTime;
		if( start < timer && timer < start+1f) {
			alpha = (timer-start);
		} 
		if( end < timer && timer < end+1f) {
			alpha = 1f-(timer-end);
		} 
		if( end+1f < timer) {
			alpha = 0f;
		}
		if (alpha < 0) { alpha = 0; }
		if (alpha > 1) { alpha = 1; }

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = 0;

		if (timer > start) {
			GUI.DrawTexture(new Rect(px,py,sx,sy), instruction, ScaleMode.ScaleToFit);
		}


	}
}
