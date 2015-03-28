using UnityEngine;
using System.Collections;

public class HeadquarterParameters : MonoBehaviour {

    private int score;

	// Use this for initialization
	void Start () {
        this.GetComponent<Health>().setHealth(100);
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //tracking health is done in the health script
        if (this.GetComponent<Health>().hasNoHealth())
        Debug.Log(this.GetComponent<Health>().getHealth());
	}
}
