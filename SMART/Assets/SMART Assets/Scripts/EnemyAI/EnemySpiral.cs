using UnityEngine;
using System.Collections;

public class EnemySpiral : MonoBehaviour {
	public GameObject Headquarters;
	public Animation enemyAnim;
	public float animSpeed;
	public float attackDistance;
	public float rotateSpeed;
	public float moveSpeed;
	public int cooldown;
	public int health;
	public Transform explosion;
	public int attackDamage = 5;

	private float distance;
	private UnityEngine.Vector3 HQpos;
	private bool isAttack = false;
	private int timer;
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
		HQpos = Headquarters.transform.position;
		distance = Vector3.Distance(HQpos, this.transform.position);
		if (distance <= attackDistance) {
			isAttack = true;
			enemyAnim.animation.CrossFade("Attacking",0.2f);
			if (timer > cooldown) {
				hqhealth.subtractHealth(attackDamage);
				timer = 0;
			}
			timer ++;
			this.transform.LookAt (HQpos);
		}
		else {
			enemyAnim.animation.CrossFade("Flying",0.2f);
		    this.transform.LookAt (HQpos);
			transform.RotateAround(HQpos, Vector3.up, rotateSpeed * Time.deltaTime);
		    this.transform.position = Vector3.MoveTowards (this.transform.position, HQpos, moveSpeed); 
		}
		if (enemyHealth.hasNoHealth()) {
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
