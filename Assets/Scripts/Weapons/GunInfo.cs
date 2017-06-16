/*
 * GUN INFO
 * Author: Christian Gonzalez
 * Description: Stores the data for a gun object
 * as read from the JSON data repository
 */
using UnityEngine;

[System.Serializable]
public class GunInfo {
	[SerializeField]
	private string name = "uninitialized_gun";
	[SerializeField]
	private string description = "a that has not been initialized properly";
	[SerializeField]
	private float muzzleVelocity = -1;
	[SerializeField]
	private float maxJitterAngle = -1;
	[SerializeField]
	private string slug = "uninitialized_gun";

	public string Name { get { return name; } }
	public string Description { get { return description; } }
	public string Slug { get { return slug; } }
	public float MuzzleVelocity { get { return muzzleVelocity; } }
	public float MaxJitterAngle { get { return maxJitterAngle; } }
}