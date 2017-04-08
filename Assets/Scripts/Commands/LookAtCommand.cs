using UnityEngine;
/*
 * LOOK AT COMMAND
 * Author: Christian Gonzalez
 * Date Created: 16/02/2017
 * Date Modified: 16/02/2017
 * Description: Command that contains a target Vector2 and
 * commands the target actor to look at that point.
 */
public class LookAtCommand : ICommand {
	Vector2 lookPoint;

	public LookAtCommand(Vector2 _lookPoint) {
		this.lookPoint = _lookPoint;
	}

	public void Execute(GameObject actor) {
		Mover2D actorMover = actor.GetComponent<Mover2D>();
		if (actorMover != null) {
			actorMover.SnapLookAt(lookPoint);
		} else { Debug.LogError("IVALID COMMAND called on " + actor.name + ", no Mover component found"); }
	}
}
