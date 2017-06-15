/*
 * GUN DAO
 * Author: Christian Gonzalez
 * Description: Concrete implementation for accessing
 * Gun objects from the data repository
 */

using System;
using System.Collections.Generic;

public class GunDAO : IGunDAO {

	private Repository<GunInfo> repoGuns;

	public GunDAO () {
		repoGuns = new Repository<GunInfo>("guns.json");
	}

	public List<GunInfo> GetAllGuns() {
		return repoGuns.getContents();
	}

	public GunInfo GetGunByName(string nameGun) {
		List <GunInfo> guns = repoGuns.getContents();
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