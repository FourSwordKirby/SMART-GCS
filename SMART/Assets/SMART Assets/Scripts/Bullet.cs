// 2/6/2015 - Mark Mendell

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public int duration = 5; // seconds
	public int unitsPerSecond = 10;
	public int damage = 1;
	public ParticleSystem explosionSystem;
	private GameObject explosion;
	
	void Start () {
		// Destroy the object after <duration> seconds
		Destroy (gameObject, duration);
	//	Debug.Log ("Bullet instantiated.");
	}

	void Update () {
		// Move forward
		transform.Translate (Vector3.forward * Time.deltaTime * unitsPerSecond);
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
}