using UnityEngine;
/*
 * SHOOT COMMAND
 * Author: Christian Gonzalez
 * Date Created: 16/02/2017
 * Date Modified: 16/02/2017
 * Description: Command that contains a target Vector2 and
 * commands the target actor's weapon to attack.
 */

class ShootCommand : ICommand {
	Vector2 target;

	public ShootCommand(Vector2 _target) {
		this.target = _target;
	}

	public void Execute(GameObject actor) {
		Weapon myWeapon = actor.GetComponentInChildren<Gun>();

		if (myWeapon != null) {
			myWeapon.Attack(target);
		} else { Debug.LogError("IVALID COMMAND called on " +
				actor.name +
				", no Weapon component found"); }
	}
}