using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject Headquarters;
	public Animation enemyAnim;
	public float animSpeed;
	public float attackDistance;
	public float moveSpeed;
	public int cooldown;
	public int health;
	public Transform explosion;
	public int attackDamage = 5;

	private float distance;
	private bool isAttack = false;
	private int timer = 0;
	private Health hqhealth;
	private Health enemyHealth;

	// Use this for initialization
	void Start () {
		timer = cooldown;
		Headquarters = GameObject.FindGameObjectWithTag ("Player");
		enemyHealth = gameObject.AddComponent<Health>();
		enemyHealth.setHealth(health);
		hqhealth = Headquarters.GetComponent<Health> ();
		enemyAnim.animation ["Flying"].speed = animSpeed;
		enemyAnim.animation ["Attacking"].speed = animSpeed;
		enemyAnim.animation ["Crawling"].speed = animSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(Headquarters.transform.position, this.transform.position);
		if (distance <= attackDistance) {
			isAttack = true;
			enemyAnim.animation.CrossFade("Attacking",0.2f);
			if (timer > cooldown) {
				hqhealth.subtractHealth(attackDamage);
				timer = 0;
			}
			timer ++;
			this.transform.LookAt (Headquarters.transform.position);
		}
		else {
			enemyAnim.animation.CrossFade("Flying",0.2f);
		    this.transform.LookAt (Headquarters.transform.position);
		    this.transform.position = Vector3.MoveTowards (this.transform.position, Headquarters.transform.position, moveSpeed); 
	    }

		if (enemyHealth.hasNoHealth()) {
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
