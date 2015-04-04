// 2/27/2015 - Mark Mendell (aka Speed McGee)

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	private int health;

	public int getHealth() {
		return this.health;
	}

	public void setHealth(int health) {
		this.health = health;
	}

	public void subtractHealth(int damage) {
		if (this.health - damage >= 0) {
			this.health -= damage;
		}
	}

	public void addHealth(int health) {
		this.health += health;
	}

	public bool hasNoHealth() {
		return (this.health <= 0);
	}
}
