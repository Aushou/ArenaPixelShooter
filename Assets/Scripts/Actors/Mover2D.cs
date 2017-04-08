using UnityEngine;
using System.Collections;

/*
 * MOVER 2D COMPONENT
 * Author: Christian Gonzalez
 * Created: 15/02/2017
 * Modified: 27/02/2017
 * Description: Handles the movement of the object it is attached to.
 * Contains a variety of methods to affect the objects velocity/acceleration
 */

public class Mover2D : MonoBehaviour {
	
	/* Name: Movement Type
	 * Description: Contains settings for various movement types for configuring
	 * how movement feels
	 */
	public enum MovementType {
		ModifyPosition,
		ModifyVelocity,
		ModifyAcceleration
	};

	/*
	 * FIELDS
	 */
	private Transform myTransform;

	private bool inputRecieved = false;
	private Vector2 currentVelocity = Vector2.zero;
	// CONFIG
	public MovementType movementType = MovementType.ModifyPosition;
	public float maxSpeed = 2f;
	public float acceleration = 1f;
	private float stopSnapRange = 0.25f;

	/*
	 * INITIALIZATION
	 */
	private void Start() {
		myTransform = GetComponent<Transform>();
	}

	private void Update() {
		myTransform.position = ((Vector2) myTransform.position + currentVelocity * Time.deltaTime);
		if(!inputRecieved) {
			Decelerate();
		}
		inputRecieved = false;
	}

	/*
	 * COMMAND METHODS
	 */
	public void Move(Vector2 movementVector) {
		inputRecieved = true;

		switch (movementType) {
			case MovementType.ModifyAcceleration:
				Debug.LogError(gameObject.name + "'s Mover.Update(): Movement type not supported");
				break;
			case MovementType.ModifyVelocity:
				AddVelocity(movementVector);
				break;
			case MovementType.ModifyPosition:
				Translate(movementVector);
				break;
			default:
				Debug.LogError(gameObject.name + "'s Mover.Update(): switch(MovementType) case not found, how did you even get here?");
				break;
		}
	}

	/* Name: Translate
	 * Input: (Vector2) Movement Vector
	 * Output: None
	 * Description: Translates attached transform by given Vector2
	 */
	private void Translate(Vector2 movementVector) {
		currentVelocity = (movementVector * maxSpeed);
	}

	/* Name: AddVelocity
	 * Input: (Vector2) MovementVector
	 * Output: None
	 * Description: Modifies current velocity by the given vector
	 * and possible acceleration
	 */
	 private void AddVelocity(Vector2 movementVector) {
		Vector2 newVelocity = currentVelocity + movementVector.normalized * (acceleration * Time.deltaTime);

		if (newVelocity.magnitude <= maxSpeed) {
			currentVelocity = newVelocity;
		} else {
			currentVelocity = Vector2.ClampMagnitude(newVelocity, maxSpeed); 
		}
	}

	/* Name: Decelerate
	 * Input: None
	 * Ouput: None
	 * Description: Handles end-of-frame deceleration according movement mode.
	 *	Modify position immediately loses all velocity
	 *	Modify velocity slows by acceleration
	 *	Modify acceleration is not yet supported
	 */
	private void Decelerate() {
		switch (movementType) {
			case MovementType.ModifyAcceleration:
				Debug.LogError(gameObject.name + "'s Mover.Update(): Movement type not supported");
				break;
			case MovementType.ModifyVelocity:
				if (currentVelocity.magnitude > stopSnapRange) {
					AddVelocity(-currentVelocity);
				} else {
					currentVelocity = Vector2.zero;
				}
				break;
			case MovementType.ModifyPosition:
				currentVelocity = Vector2.zero;
				break;
			default:
				Debug.LogError(gameObject.name + "'s Mover.Update(): switch(MovementType) case not found, how did you even get here?");
				break;
		}
	}


	/*
	 * ROTATION METHODS
	 */
	public void SnapLookAt(Vector2 target) {
		Vector2 directionalVector;

		//directionalVector = target - (Vector2) myTransform.position;
		directionalVector = Vector2.up;

		myTransform.up = directionalVector;
	}
}
