using UnityEngine;
using System.Collections;

/*
 * A lightning bullet extends a cube from the turret to the enemy.
 */
public class LightningBullet : MonoBehaviour {
	
	public GameObject turret;				//The turret holding the lighting gun
	public GameObject lightningPrefab;		//lightning prefab image
	public int rangeOfFire = 5;
	public int damage = 1;
	public float coolDownPeriodInSeconds = 2;	//Wait time until next bullet fire
	private float nextBulletAllowed; 		//Window for next bullet fired
	public ParticleSystem turretExplosionSystem;
	public ParticleSystem enemyExplosionSystem;

	//Constants
	private static string ENEMY_TAG = "Untagged";

	// Use this for initialization
	void Start () {
		//lightningPrefab = (GameObject)Instantiate (lightningPrefab, turret.transform.position , turret.transform.rotation);
		nextBulletAllowed = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		//If cool down period is over then findEnemy and shoot
		if (Time.time > nextBulletAllowed) {
			findEnemy ();		
		}
	}

	/*
	 * Finds the enemy using a rayCast and then calls the shootBullet method to shoot the bullet. 
	 * 
	 * Returns: void
	 */
	private void findEnemy() {

		GameObject enemy = FindClosestEnemy (); 
		if (enemy != null) {
			if(Vector3.Distance(enemy.transform.position, turret.transform.position) <= rangeOfFire) {
				shootBullet (enemy);
				nextBulletAllowed = Time.time + coolDownPeriodInSeconds;
			}
		}
		//Debug.Log("no enemy");
	}

	/*
	 * Shoots the lightning bullet by extending the lightningPrefab from the turret tip to the enemy position 
	 * 
	 * Param1: Collider enemy - the enemy the bullet should be shot at
	 * Returns: void
	 */
	private void shootBullet(GameObject enemy) {

		//Instantiates the prefab
		GameObject lightningClone = (GameObject)Instantiate (lightningPrefab, turret.transform.position , turret.transform.rotation);

		//Spawn the explosions
		spawnExplosionAtTurret ();
		spawnExplosionAtEnemy (enemy);

		var enemyHealth = enemy.GetComponent<Health>();
		if (enemyHealth != null) {
			enemyHealth.subtractHealth(damage);
		}

		Vector3 posDiff = enemy.transform.position - turret.transform.position;
		lightningClone.transform.localScale = new Vector3(1,1,posDiff.z);

		//Deletes the prefab after coolDownPeriodInSeconds
		Destroy (lightningClone, coolDownPeriodInSeconds);
	
	}
	
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

	void spawnExplosionAtTurret() {
		ParticleSystem newExplosion = Instantiate (turretExplosionSystem) as ParticleSystem;
		newExplosion.transform.position = turret.transform.position;
		newExplosion.transform.rotation = Quaternion.identity;
		newExplosion.Play ();
	}

	void spawnExplosionAtEnemy(GameObject enemy) {
		ParticleSystem newExplosion = Instantiate (enemyExplosionSystem) as ParticleSystem;
		newExplosion.transform.position = enemy.transform.position;
		newExplosion.transform.rotation = Quaternion.identity;
		newExplosion.Play ();
	}
}
