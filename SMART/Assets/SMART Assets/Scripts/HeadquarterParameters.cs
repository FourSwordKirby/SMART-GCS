using UnityEngine;
using System.Collections;

public class HeadquarterParameters : MonoBehaviour {

	public ParticleSystem explosion;
	public float secondsBeforeRestartAfterDeath = 5.0f;
	public int health = 100;
    private int score;
	private bool died = false;
	private bool waitingToRestart = false;
	private float timeToRestart;

	// Use this for initialization
	void Start () {
        this.GetComponent<Health>().setHealth(this.health);
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //tracking health is done in the health script
        if (this.GetComponent<Health>().hasNoHealth() && !this.died) {
			this.die();
		}
		if (this.waitingToRestart && Time.time >= this.timeToRestart) {
			Application.LoadLevel (0);
		}
	}

	void die() {
		this.died = true;
		this.spawnExplosion ();
		// Make it disappear
		gameObject.transform.localScale = new Vector3 (0, 0, 0);
		this.waitingToRestart = true;
		this.timeToRestart = Time.time + this.secondsBeforeRestartAfterDeath;
	}

	void spawnExplosion() {
		ParticleSystem newExplosion = Instantiate (explosion) as ParticleSystem;
		newExplosion.transform.position = gameObject.transform.position;
		newExplosion.Play ();
	}
}
