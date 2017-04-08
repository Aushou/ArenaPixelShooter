using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * COMMAND HANDLER
 * Author: Christian Gonzalez
 * Date Created: 02/15/2017
 * Date Modified: 02/15/2017
 * Description: Has two public functions to handle a single command
 * or list of commands. Calls the execute funciton on them with the
 * gameObject this Component is attached to as the target. Allows any
 * other script to manipulate this object.
 */

public class CommandHandler : MonoBehaviour {
	public void HandleCommands(List<ICommand> commands) {
		/* INPUT: <List<ICommand>) List of Commands to Execute
		 * DESCRIPTION: Executes a list of commands with this object as
		 * the target
		 */
		if (commands.Count > 0) {
			foreach (ICommand command in commands) {
				command.Execute(gameObject);
			}
		}
	}

	public void HandleCommand(ICommand command) {
		/* INPUT: (ICommand) Command to Execute
		 * DESCRIPTION: Executes a command with this object as the target
		 */
		command.Execute(gameObject);
	}
}
