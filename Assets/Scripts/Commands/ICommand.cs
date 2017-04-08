using UnityEngine;

/*
 * COMMAND INTERFACE
 * Author: Christian Gonzalez
 * Date Created: 15/02/2017
 * Date Modified: 15/02/2017
 * Description: Base contract for a command object that can be Executed
 * and has a target gameObject
 */

public interface ICommand {
	void Execute(GameObject actor);
}