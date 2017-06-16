using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseHost : MonoBehaviour {

	// Use this for initialization
	void Start () {

		IGunDAO gunDAO = new GunDAO();
		List<GunInfo> listInfoGuns = gunDAO.GetAllGuns();
		foreach (GunInfo item in listInfoGuns) {
			Debug.Log("Name: " + item.Name +
				"\nDescription: " + item.Description +
				"\nMuzzle Velocity: " + item.MuzzleVelocity +
				"\nMax Jitter: " + item.MaxJitterAngle +
				"\nSlug: " + item.Slug);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
