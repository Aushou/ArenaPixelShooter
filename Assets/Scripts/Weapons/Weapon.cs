using UnityEngine;
/*
 * BASE WEAPON
 * Author: Christian Gonzalez
 * Date Created: 16/02/2017
 * Date Modified: 16/02/2017
 * Description: Base weapon that all other weapons
 * should extend from.
 */

public abstract class Weapon : MonoBehaviour {
	public abstract void Attack(Vector2 target);
}