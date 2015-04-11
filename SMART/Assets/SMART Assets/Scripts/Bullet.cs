// 2/6/2015 - Mark Mendell

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public int duration = 5; // seconds
	public int unitsPerSecond = 10;
	public int damage = 1;
	public ParticleSystem explosionSystem;
	public ParticleSystem missileTrail;
	private int frameCounter = 0;

	void Start () {
		// Destroy the object after <duration> seconds
		Destroy (gameObject, duration);
	//	Debug.Log ("Bullet instantiated.");
		if (missileTrail != null) {
			this.spawnTrail ();
		}
	}

	void Update () {
		// Move forward
		transform.Translate (Vector3.forward * Time.deltaTime * unitsPerSecond);
		if (frameCounter % 2 == 0) {
			this.spawnTrail ();
		}
		frameCounter++;
	}

	void OnTriggerEnter (Collider collision) {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.subtractHealth(damage);
        }

		this.spawnExplosion();
		Destroy (gameObject);
	}

	void spawnExplosion() {
		ParticleSystem newExplosion = Instantiate (explosionSystem) as ParticleSystem;
		newExplosion.transform.position = gameObject.transform.position;
		newExplosion.transform.rotation = Quaternion.identity;
		newExplosion.Play ();
	}
	void spawnTrail() {
		ParticleSystem newExplosion = Instantiate (missileTrail) as ParticleSystem;
		newExplosion.transform.position = gameObject.transform.position;
		newExplosion.transform.rotation = Quaternion.identity;
		newExplosion.Play ();
	}
}