#pragma strict

//get gui texture
var title: Texture;

private var alpha: float;
alpha = 1.0;

private var timer: float;

var fadeOutStart: float;
var fadeSpeed: float;

function OnGUI()
{

//inc timer
timer += Time.deltaTime;

//start fading out
if (timer > fadeOutStart && alpha > 0)
{alpha -= Time.deltaTime*fadeSpeed;}
if (alpha < 0) {alpha = 0;}

//fade out
GUI.color.a = alpha;

GUI.depth = 0;

//draw title image
GUI.DrawTexture(Rect(0,0,Screen.width,Screen.height), title,ScaleMode.StretchToFill);

		//quit if escape key
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}

}