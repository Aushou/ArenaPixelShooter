using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PLAYER INPUT HANDLER
 * Author: Christian Gonzalez
 * Date Created: 02/15/2017
 * Date Modified: 02/15/2017
 * Description: Handles player input and converts input into commands
 * that are sent and handled by the CommandHandler
 */

[RequireComponent (typeof (CommandHandler))]
public class PlayerInputHandler : MonoBehaviour {

	/*
	 * FIELDS
	 */
	CommandHandler myCommandHandler;
	private bool inControl = false;

	/*
	 * INITIALIZATION
	 */
	private void Start() {
		myCommandHandler = GetComponent<CommandHandler>();
	}
	
	/*
	 * UPDATE
	 */
	void Update () {
		if(inControl) {
			myCommandHandler.HandleCommands(GetCommands());
		}
	}

	/*
	 * METHODS
	 */
	private List<ICommand> GetCommands() {
		/* OUTPUT: (List<ICommand>)List of Commands
		 * DESCRIPTION: Calls input checks and assembles a list of commands
		 * to send out this frame
		 */
		List<ICommand> lstCommands = new List<ICommand>();
		AddIfNotVoid(GetAction(), ref lstCommands);
		AddIfNotVoid(GetAim(), ref lstCommands);
		AddIfNotVoid(GetMovement(), ref lstCommands);

		return lstCommands;
	}

	private bool AddIfNotVoid(ICommand cmd, ref List<ICommand> lstCommands) {
		/* INPUT: (ICommand)Input Command, (ref List<ICommand>) List to Add Command To
		 * OUTPUT: (bool)Success Flag
		 * DESCRIPTION: Adds a command to the given list if it is not null
		 */
		if(cmd != null) {
			lstCommands.Add(cmd);
			return true;
		} else {
			return false;
		}
	}

	private ICommand GetAction() {
		/* OUTPUT: (ICommand)Action Command
		 * DESCRIPTION: Detects player input for actions and returns the
		 * relevant commands
		 */
		if (Input.GetKeyUp(KeyCode.Tab)) {
			return new SwapWeaponCommand();
		}
		if (Input.GetMouseButtonDown(0)) {
			Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target = target - (Vector2) transform.position;

			return new ShootCommand(target);
		}

		return null;
	}

	private ICommand GetMovement() {
		/* OUTPUT: (ICommand) Move Command w/ vector
		 * DESCRIPTION: Takes player input and builds a vector based on
		 * multiple keypresses. Builds a command out of this and returns it.
		 */
		Vector2 movementVector = Vector2.zero;
		if (Input.GetKey(KeyCode.W)) {
			movementVector = movementVector + Vector2.up;
		}
		if (Input.GetKey(KeyCode.S)) {
			movementVector = movementVector + Vector2.down;
		}
		if (Input.GetKey(KeyCode.A)) {
			movementVector = movementVector + Vector2.left;
		}
		if (Input.GetKey(KeyCode.D)) {
			movementVector = movementVector + Vector2.right;
		}

		if (movementVector != Vector2.zero) {
			return new MoveCommand(movementVector);
		} else {
			return null;
		}
	}

	public ICommand GetAim() {
		/* OUTPUT: LookAtCommand
		* DESCRIPTION: Gets mouse position and sends command to point
		* actor to that point.
		*/
		Vector2 mouseAt;

		mouseAt = Vector2.down;
		// Vector2 mouseAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		return new LookAtCommand(mouseAt);
	}

	public void toggleInControl() {
		// DESCRIPTION: Flips inControl boolean, activating or deactivating player control
		inControl = !inControl;
	} public void toggleInControl(bool setTo) {
		// INPUT: (boolean) Set Control To
		// DESCRIPTION: Sets inControl directly to True or False
		inControl = setTo;
	}
}
