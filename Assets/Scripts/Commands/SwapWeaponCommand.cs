/**
* SWAP WEAPON COMMAND
* Author: Christian Gonzalez
* Description: Command for swapping weapons
*/
using System;
using UnityEngine;

class SwapWeaponCommand : ICommand {
	public void Execute(GameObject actor) {
		Weapon myWeapon = actor.GetComponentInChildren<Gun>();

		if (myWeapon != null) {
			myWeapon.SwapWeapon();
		} else {
			Debug.LogError("INVALID COMMAND called on " +
				actor.name +
				", no weapon component found!");
		}
	}
}