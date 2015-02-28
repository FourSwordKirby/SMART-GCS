// 2/6/2015 - Mark Mendell

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public int duration = 5; // seconds
	public int unitsPerSecond = 10;
	public ParticleSystem explosionSystem;
	private GameObject explosion;
	
	void Start () {
		// Destroy the object after <duration> seconds
		Destroy (gameObject, duration);
		Debug.Log ("Bullet instantiated.");
	}

	void Update () {
		// Move forward
		transform.Translate (Vector3.forward * Time.deltaTime * unitsPerSecond);
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("Collided with something.");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.subtractHealth(1);
        }

		this.spawnExplosion();
		Destroy (gameObject);
	}

	void spawnExplosion() {
		ParticleSystem newExplosion = Instantiate (explosionSystem) as ParticleSystem;
		newExplosion.transform.position = gameObject.transform.position;
		newExplosion.Play ();
		Debug.Log ("Spawned an explosion.");
	}
}