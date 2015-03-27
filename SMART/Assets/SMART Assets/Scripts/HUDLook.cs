using UnityEngine;
using System.Collections;

public class HUDLook : MonoBehaviour {
	
	public GameObject cam;

	// Update is called once per frame
	void Update () {
		transform.LookAt(cam.transform.position);
		transform.rotation = cam.transform.rotation;
	}
}
