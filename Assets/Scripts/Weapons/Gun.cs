using UnityEngine;

/*
 * GUN
 * Author: Christian Gonzalez
 * Date Created: 16/02/2017
 * Date Modified: 27/02/2017
 * Description: Base gun that other guns should
 * extend from.
 */

public class Gun : Weapon {

	/*
	 * FIELDS
	 */
	public GameObject myBullet;
	private Transform myTransform;
	private Transform firePointTransform;
	// Settings
	public bool debug = false;			// Debug mode active?
	public float muzzleVelocity = 0;	// Fired projectile speed
	public float maxJitterAngle = 0;	// Max aim drift

	/*
	 * INITIALIZATION
	 */
	public void Start() {
		myTransform = GetComponent<Transform>();
		firePointTransform = myTransform.FindChild("FirePoint");
	} 

	/*
	 * METHODS
	 */
	public override void Attack(Vector2 target) {
		GameObject firedProjectile = Instantiate(myBullet, firePointTransform.position, Quaternion.identity);
		firedProjectile.GetComponent<Bullet>().Configure(CalculateShotAngle(target.normalized), muzzleVelocity);
	}

	/* Name: Calculate Shot Angle
	 * Input: (Vector2) Vector representing base aim
	 * Output: (Vector2) Actual bullet path
	 * Description: Applies inaccuracy to bullet
	 */
	public Vector2 CalculateShotAngle(Vector2 aimAngle) {
		Vector2 calculatedShotAngle = aimAngle;

		Quaternion scatterRotation = Quaternion.AngleAxis(Random.Range(-maxJitterAngle, maxJitterAngle), Vector3.forward);
		calculatedShotAngle = scatterRotation * aimAngle;

		/* Debug lines */
		if (debug) {
			Debug.DrawRay(firePointTransform.position, aimAngle, Color.blue, 0.5f);
			Debug.DrawRay(firePointTransform.position, calculatedShotAngle, Color.red, 0.5f);
		}
		return calculatedShotAngle;
	}
}
