using UnityEngine;
using System.Collections;

public class DecayingSinusoidEnemyAI : MonoBehaviour {

	public GameObject hq;
	public GameObject enemy;
	public float forwardSpeed;
	public float startAmplitude;
	private Vector3 pathPosition;
	private float totalDist;

	// Use this for initialization
	void Start () {
		//enemy.renderer.material.color = Color.black;
		totalDist = Vector3.Distance (enemy.transform.position, hq.transform.position);
		pathPosition = enemy.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (pathPosition, hq.transform.position);
		Vector3 temp = new Vector3 (0,0,0);
		if (dist > 1.0f) {
			Vector3 oldPosition = pathPosition;
			pathPosition = Vector3.MoveTowards (pathPosition, hq.transform.position, forwardSpeed);
			float rise = pathPosition.y - oldPosition.y;
			float run = pathPosition.x - oldPosition.x;
			temp.x =  pathPosition.x + rise*startAmplitude*(dist/totalDist)*Mathf.Sin (dist*(4*Mathf.PI)/totalDist);
			temp.y =  pathPosition.y - run*startAmplitude*(dist/totalDist)*Mathf.Sin (dist*(4*Mathf.PI)/totalDist);
			enemy.transform.position = temp;
		} else {
			//enemy.renderer.material.color = Color.red;
		}
	}
}
