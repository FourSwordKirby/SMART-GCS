using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject Headquarters;
	public float attackDistance;
	public float moveSpeed;

	private float distance;
	private bool isAttack = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(Headquarters.transform.position, this.transform.position);
		if (distance <= attackDistance) {
			if (!isAttack) {
				isAttack = !isAttack;
				//should play an attack animation; for now will just change color.
				//this.renderer.material.color = Color.black;
			}
			this.transform.LookAt (Headquarters.transform.position);
		}
		else {
			if (isAttack) {
				isAttack = !isAttack;
				//should stop attacking; for now will just change color back. 
				//this.renderer.material.color = Color.white;
			}
		    this.transform.LookAt (Headquarters.transform.position);
		    this.transform.position = Vector3.MoveTowards (this.transform.position, Headquarters.transform.position, moveSpeed); 
	    }
	}
}
