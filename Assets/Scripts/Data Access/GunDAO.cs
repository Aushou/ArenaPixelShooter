/*
 * GUN DAO
 * Author: Christian Gonzalez
 * Description: Concrete implementation for accessing
 * Gun objects from the data repository
 */

using System;
using System.Collections.Generic;

public class GunDAO : IGunDAO {

	private GunRepository repoGuns;

	public GunDAO () {
		repoGuns = GunRepository.Instance;
	}

	public List<GunInfo> GetAllGuns() {
		return repoGuns.Contents;
	}

	public GunInfo GetGunInfoByName(string nameGun) {
		List <GunInfo> guns = repoGuns.Contents;
		GunInfo output = new GunInfo();

		foreach(GunInfo gun in guns) {
			if (gun.Name == nameGun) {
				output = gun;
				break;
			}
		}

		// TODO: Throw an error instead of return null
		return output;
	}
}