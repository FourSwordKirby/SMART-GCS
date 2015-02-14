// 2/13/2015 - Mark Mendell

using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private ParticleSystem ps;
	
	void Start () {
		ps = GetComponent<ParticleSystem> ();
	}

	void Update () {
		// Check if done exploding
		if (!ps.IsAlive ())
			Destroy (gameObject);
	}
}
