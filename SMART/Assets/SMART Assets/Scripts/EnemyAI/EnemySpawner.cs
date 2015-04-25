using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject Headquarters;
	public GameObject[] enemies;
	public float distance;
	public float cooldown;
	public float cooldownChange;
	public float minCooldown;
	public float scale;
	public int enemyCap;

	private float lastSpawnTime;
	private Vector3 hqPos;
	// Use this for initialization
	void Start () {
		lastSpawnTime = Time.fixedTime;
		hqPos = Headquarters.transform.position;
		gameObject.transform.position = hqPos + new Vector3 (distance, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (countEnemy() < enemyCap && Time.fixedTime - lastSpawnTime > cooldown) {
			gameObject.transform.position = randomRotate (gameObject.transform.position, hqPos);
			int enemyIndex = Random.Range (0, enemies.Length);
			GameObject newEnemy = Instantiate(enemies[enemyIndex], gameObject.transform.position, 
			                                  Quaternion.identity) as GameObject;
			newEnemy.transform.localScale = newEnemy.transform.localScale * scale;
			Debug.Log ("Spawned");
			if (cooldown > minCooldown) {
				cooldown -= cooldownChange;
			}
			lastSpawnTime = Time.fixedTime;
		}
	}

	int countEnemy() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		return gos.Length;
	}

	Vector3 randomRotate (Vector3 point, Vector3 pivot) {
		Vector3 dir = point - pivot;
		dir = Quaternion.Euler (new Vector3 (Random.Range (0, 45), 
		                                   Random.Range (0, 360), 
		                                   Random.Range (0, 360))) * dir;
		return dir + pivot;
	}
}
