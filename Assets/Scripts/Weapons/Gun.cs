using UnityEngine;

/*
 * GUN
 * Author: Christian Gonzalez
 * Description: Base gun that other guns should
 * extend from.
 */

public class Gun : Weapon {

	public GameObject myBullet;
	private Transform myTransform;
	private Transform firePointTransform;
	// Settings
	public bool debug = false;      // Debug mode active?
	IGunDAO gunInfoDAO;
	GunInfo stats;

	/*
	 * INITIALIZATION
	 */
	public void Start() {
		gunInfoDAO = new GunDAO();    // TODO: Consider using service locator pattern
		stats = gunInfoDAO.GetGunInfoByName("The Gun");
		myTransform = GetComponent<Transform>();
		firePointTransform = myTransform.FindChild("FirePoint");
	} 

	/*
	 * METHODS
	 */
	public override void Attack(Vector2 target) {
		GameObject firedProjectile = Instantiate(myBullet, firePointTransform.position, Quaternion.identity);
		firedProjectile.GetComponent<Bullet>().Configure(CalculateShotAngle(target.normalized), stats.MuzzleVelocity);
	}

	/* Name: Calculate Shot Angle
	 * Input: (Vector2) Vector representing base aim
	 * Output: (Vector2) Actual bullet path
	 * Description: Applies inaccuracy to bullet
	 */
	public Vector2 CalculateShotAngle(Vector2 aimAngle) {
		Vector2 calculatedShotAngle = aimAngle;

		Quaternion scatterRotation = Quaternion.AngleAxis(Random.Range(-stats.MaxJitterAngle, stats.MaxJitterAngle), Vector3.forward);
		calculatedShotAngle = scatterRotation * aimAngle;

		/* Debug lines */
		if (debug) {
			Debug.DrawRay(firePointTransform.position, aimAngle, Color.blue, 0.5f);
			Debug.DrawRay(firePointTransform.position, calculatedShotAngle, Color.red, 0.5f);
		}
		return calculatedShotAngle;
	}
}
