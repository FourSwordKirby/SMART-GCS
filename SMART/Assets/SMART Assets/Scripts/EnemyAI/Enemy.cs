using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject Headquarters;
	public float attackDistance;
	public float moveSpeed;
	public int cooldown;

	private float distance;
	private bool isAttack = false;
	private int timer = 0;
	private int attackDamage = 5;
	private Health hqhealth;

	// Use this for initialization
	void Start () {
		timer = cooldown;
		hqhealth = Headquarters.GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(Headquarters.transform.position, this.transform.position);
		if (distance <= attackDistance) {
			isAttack = true;
			if (timer > cooldown) {
				hqhealth.subtractHealth(attackDamage);
				timer = 0;
			}
			timer ++;
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
