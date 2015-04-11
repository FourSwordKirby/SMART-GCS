using UnityEngine;
using System.Collections;

public class TurretShootBullet : MonoBehaviour {

	public float bulletsPerSecond = 5;
	public float range = 60;
	public GameObject bullet;
	public Transform[] fireLocations;
	public ParticleSystem muzzleFlash;

	private float secondsBetweenBullets;
	private float lastBulletFire = 0.0f;
	private int fireIndex = 0;
	
	void Start () {
		this.secondsBetweenBullets = 1.0f / this.bulletsPerSecond;
	}

	void Update () {
		GameObject closestEnemy = this.FindClosestEnemy ();
		float distance = Vector3.Distance (gameObject.transform.position, closestEnemy.transform.position);
		if ((Time.time > this.lastBulletFire + this.secondsBetweenBullets) && (distance < this.range)) {
			this.FireBullet();
		}
	}

	//Unity Scripting Example to find the closest enemy
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

	void FireBullet() {
		Transform fireLocation = this.fireLocations [this.fireIndex];
		Instantiate (this.bullet, fireLocation.position, fireLocation.rotation);
		Instantiate (this.muzzleFlash, fireLocation.position, fireLocation.rotation);
		this.lastBulletFire = Time.time;
		this.fireIndex = (this.fireIndex + 1) % this.fireLocations.Length;
	}
}
