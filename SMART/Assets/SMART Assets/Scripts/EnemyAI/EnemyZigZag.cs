using UnityEngine;
using System.Collections;

public class EnemyZigZag : MonoBehaviour {
	public GameObject Headquarters;
	public float attackDistance;
	public float moveSpeed;
	public int cooldown;
	public int health;
	public Transform explosion;
	public int attackDamage = 5;

	private float distance;
	private float pingpong = 0.6f;
	private UnityEngine.Vector3 HQpos;
	private bool isAttack = false;
	private int timer = 0;
	private Health hqhealth;
	private Health enemyHealth;

	// Use this for initialization
	void Start () {
		Headquarters = GameObject.FindGameObjectWithTag ("Player");
		HQpos = Headquarters.transform.position;
		timer = cooldown;
		enemyHealth = gameObject.AddComponent<Health>();
		enemyHealth.setHealth(health);
		hqhealth = Headquarters.GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(HQpos, this.transform.position);
		if (distance <= attackDistance) {
			isAttack = true;
			if (timer > cooldown) {
				hqhealth.subtractHealth(attackDamage);
				timer = 0;
			}
			timer ++;
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
		
		if (enemyHealth.hasNoHealth()) {
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
