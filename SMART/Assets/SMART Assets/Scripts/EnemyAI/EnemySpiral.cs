using UnityEngine;
using System.Collections;

public class EnemySpiral : MonoBehaviour {
	public GameObject Headquarters;
	public float attackDistance;
	public float rotateSpeed;
	public float moveSpeed;

	private float distance;
	private UnityEngine.Vector3 HQpos;
	private bool isAttack = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		HQpos = Headquarters.transform.position;
		distance = Vector3.Distance(HQpos, this.transform.position);
		if (distance <= attackDistance) {
			if (!isAttack) {
				isAttack = !isAttack;
				//should play an attack animation; for now will just change color.
				//this.renderer.material.color = Color.black;
			}
			this.transform.LookAt (HQpos);
		}
		else {
			if (isAttack) {
				isAttack = !isAttack;
				//should stop attacking; for now will just change color back. 
				//this.renderer.material.color = Color.white;
			}
		    this.transform.LookAt (HQpos);
			transform.RotateAround(HQpos, Vector3.up, rotateSpeed * Time.deltaTime);
		    this.transform.position = Vector3.MoveTowards (this.transform.position, HQpos, moveSpeed); 
	    }
	}
}
