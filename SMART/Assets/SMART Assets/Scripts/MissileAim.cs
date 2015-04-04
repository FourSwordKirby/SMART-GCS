using UnityEngine;
using System.Collections;

public class MissileAim : MonoBehaviour {
	
	public Transform target;
	public float rotationSpeed = 100.0f;
	
	// Use this for initialization
	void Start () {
		target = FindClosestEnemy ().transform;
	}
	
	// http://forum.unity3d.com/threads/tank-heat-seeking-missile.144554/#post-990037
	void Update () {
		if (target == null) {
			target = FindClosestEnemy ().transform;
		}	
		Vector3 targetDirection = target.position - gameObject.transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
		gameObject.transform.rotation = Quaternion.RotateTowards(
			gameObject.transform.rotation,
			targetRotation,
			rotationSpeed * Time.deltaTime);
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