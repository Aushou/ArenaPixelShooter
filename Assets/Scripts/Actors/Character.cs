using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMortal {
	/*
	 * FIELDS
	 */
	/* ATTRIBUTES */
	private float maxHealth = 10;
	private float health;

	/*
	 * METHODS
	 */
	void Start() {
		health = maxHealth;
	}

	void Update() {
		CheckDeath();
	}

	/* CHECK DEATH (IMortal)
	 * Input: None
	 * Output: None
	 * Description: Kills the character if they should die this frame
	 */
	public void CheckDeath() {
		if (health <= 0) {
			Kill();
		}
	}

	/* DAMAGE (IDamageable)
	 * Input: (float) Amount Damage
	 * Output: (float) Updated Health
	 * Description: Handles damaging the character
	 */
	public float Damage(float amtDamage) {
		health = health - amtDamage;
		return health;
	}

	/* Kill (IMortal)
	 * Input: None
	 * Output: None
	 * Description: Handles the death event of this character
	 */
	public void Kill() {
		Destroy(gameObject);
	}
}
