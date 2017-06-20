/*
 * GUN REPOSITORY
 * Author: Christian Gonzalez
 * Description: Concrete implementation of a singleton
 * repository for storying GunInfo objects
 */
using System.Collections.Generic;

public sealed class GunRepository : IRepository <GunInfo> {
	private static readonly GunRepository instance = new GunRepository();
	private List<GunInfo> contents;

	private GunRepository() {
		string filepath = "Assets/data/repositories/guns.json";  // TODO: Read from config file
		contents = JsonListHelper.GetListFromFilepath<GunInfo>(filepath);
	}

	public static GunRepository Instance {
		get {
			return instance;
		}
	}

	public List<GunInfo> Contents {
		get {
			return contents;
		}
	}
}