using UnityEngine;
using System.Collections;

public class SinusoidEnemyAI : MonoBehaviour {

	public GameObject hq;
	public GameObject enemy;
	public float forwardSpeed;
	public float amplitude;
	public float attackDistance;
	public int cooldown;
	public int health;
	public Transform explosion;
	public int attackDamage = 5;

	private Vector3 pathPosition;
	private float totalDist;
	private int timer;
	private Health hqhealth;
	private Health enemyHealth;
	private bool isAttack = false;

	// Use this for initialization
	void Start () {
		//enemy.renderer.material.color = Color.black;
		hq = GameObject.FindGameObjectWithTag ("Player");
		totalDist = Vector3.Distance (enemy.transform.position, hq.transform.position);
		pathPosition = enemy.transform.position;
		enemy.transform.LookAt(hq.transform);
		timer = cooldown;
		enemyHealth = gameObject.AddComponent<Health>();
		enemyHealth.setHealth(health);
		hqhealth = hq.GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (pathPosition, hq.transform.position);
		Vector3 temp = new Vector3 (0,0,0);
		if (dist <= attackDistance) {
			isAttack = true;
			if (timer > cooldown) {
				hqhealth.subtractHealth(attackDamage);
				timer = 0;
			}
			timer ++;
			this.transform.LookAt (hq.transform.position);
		}
		else {
			if (isAttack) {
				isAttack = !isAttack;
				//should stop attacking; for now will just change color back. 
				//this.renderer.material.color = Color.white;
			}
			Vector3 oldPosition = pathPosition;
			pathPosition = Vector3.MoveTowards (pathPosition, hq.transform.position, forwardSpeed);
			float rise = pathPosition.x - oldPosition.x;
			float run = pathPosition.z - oldPosition.z;
			temp.z =  pathPosition.z + rise*amplitude*Mathf.Sin (dist*(16*Mathf.PI)/totalDist);
			temp.x =  pathPosition.x - run*amplitude*Mathf.Sin (dist*(16*Mathf.PI)/totalDist);
			enemy.transform.position = temp;
			enemy.transform.LookAt(hq.transform);
		}
		if (enemyHealth.hasNoHealth()) {
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
