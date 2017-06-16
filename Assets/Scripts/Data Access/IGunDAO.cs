/*
 * INTERFACE: GUN DAO
 * Author: Christian Gonzalez
 * Description: Class responsible for extracting data from
 * repository classes in useful ways.
 */
using System.Collections.Generic;

public interface IGunDAO {
	List<GunInfo> GetAllGuns();
	GunInfo GetGunByName(string nameGun);
}