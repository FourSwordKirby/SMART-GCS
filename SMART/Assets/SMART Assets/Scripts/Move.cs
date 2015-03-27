using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public Transform target;
	public float speed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 curr = rigidbody.position;
		Vector3 targetpos = target.position;
		
		transform.rotation = Quaternion.FromToRotation (Vector3.up, targetpos - curr);
		transform.Translate (Vector3.up * speed * Time.deltaTime);
	}
}