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
	}
	
	// Update is called once per frame
	void Update () {
		if (FrameRate.started == true) {
			if (countEnemy() < (enemyCap + 1) && Time.fixedTime - lastSpawnTime > cooldown) {
				int enemyIndex = Random.Range (0, enemies.Length);
				GameObject newEnemy = Instantiate(enemies[enemyIndex], gameObject.transform.position, 
				                                  gameObject.transform.rotation) as GameObject;
				newEnemy.transform.localScale = newEnemy.transform.localScale * scale;
				newEnemy.transform.Rotate(Random.Range (0, 45),Random.Range (0, 360),0);
				newEnemy.transform.Translate(0,0,-distance);

				Debug.Log ("Spawned");
				if (cooldown > minCooldown) {
					cooldown -= cooldownChange;
				}
				lastSpawnTime = Time.fixedTime;
			}
		}
	}

	int countEnemy() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		return gos.Length;
	}

}
