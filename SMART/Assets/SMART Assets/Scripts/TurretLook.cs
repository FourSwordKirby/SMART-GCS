using UnityEngine;
using System.Collections;

public class TurretLook : MonoBehaviour {

	//initialize variables
	public float lookSpeed = 1.0f;
	private GameObject target;

	// Update is called once per frame
	void Update () {

		//get target
		target = FindClosestEnemy();

		//look at target
		Vector3 curr = transform.position;
		Vector3 targetpos = target.transform.position;
		Quaternion look = Quaternion.LookRotation (targetpos - curr, Vector3.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, look, lookSpeed * Time.deltaTime);
	}

	//Unity Scripting Example to find the closest enemy
	GameObject FindClosestEnemy() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = gos[0];
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if(curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
	
}
