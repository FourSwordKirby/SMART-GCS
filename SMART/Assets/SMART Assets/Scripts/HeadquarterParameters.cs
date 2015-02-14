using UnityEngine;
using System.Collections;

public class HeadquarterParameters : MonoBehaviour {

    private int health;
    private int score;

	// Use this for initialization
	void Start () {
        health = 30;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (health != 30)
        {
            Debug.Log("I died");
        }
	}

    void takeDamage(int damage)
    {
        this.health -= damage;
    }
}
