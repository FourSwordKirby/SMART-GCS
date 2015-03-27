using UnityEngine;
using System.Collections;

public class EnemyZigZag : MonoBehaviour {
	public GameObject Headquarters;
	public float attackDistance;
	public float moveSpeed;

	private float distance;
	private float pingpong = 0.6f;
	private UnityEngine.Vector3 HQpos;
	private bool isAttack = false;

	// Use this for initialization
	void Start () {
		HQpos = Headquarters.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
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
			float zigamount = -pingpong + Mathf.PingPong(Time.time, pingpong);
			this.transform.LookAt (HQpos);
			this.transform.position += zigamount * this.transform.right;
		    this.transform.position = Vector3.MoveTowards (this.transform.position, HQpos, moveSpeed); 
	    }
	}
}
