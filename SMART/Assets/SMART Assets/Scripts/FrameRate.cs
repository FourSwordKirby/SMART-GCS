using UnityEngine;
using System.Collections;

public class FrameRate : MonoBehaviour 
{

	public  float updateInterval = 0.5F;
	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
	public float timeSinceStart;
	public float fps;
	public static bool started = false;
	public AudioClip[] audioClips;

	void Start() { 
		AudioListener.volume = 2f;
		timeleft = updateInterval; 
		started = false;
		audio.clip = audioClips[Random.Range(0,audioClips.Length)]; 
	}
	
	void Update()
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - update GUI text and start new interval
		if( timeleft <= 0.0 ) {
			// display two fractional digits (f2 format)
			fps = accum/frames;
			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
		}
		if(started) {
			timeSinceStart+=Time.deltaTime;
		} else if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0)) {
			started = true;
			audio.Play();
		}
	}

	void OnGUI() {
		GUI.skin.label.fontSize = 24;
		GUI.Label(new Rect(20,10,1000,100), "FPS: " + fps.ToString() );
		if(started) {
			GUI.Label(new Rect(20,40,1000,100), "Time since start: " + ((int)timeSinceStart).ToString() );
		} else {
			GUI.Label(new Rect(20,40,1000,100), "Press mouse or touch to start" );
		}
	}
}