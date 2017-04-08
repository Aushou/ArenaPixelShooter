using UnityEngine;

class MoveCommand : ICommand {
	Vector2 moveDirection;

	public MoveCommand(Vector2 _moveDirection) {
		this.moveDirection = _moveDirection;
	}

	public void Execute(GameObject actor) {
		Mover2D actorMover = actor.GetComponent<Mover2D>();
		if (actorMover != null) {
			actorMover.Move(moveDirection);
		} else { Debug.LogError("INVALID COMMAND called on " + actor.name + ", no Mover component found"); }
	}
}
