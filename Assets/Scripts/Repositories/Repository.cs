/*
 * REPOSITORY
 * Author: Christian Gonzalez
 * Description: Base repository class all data repositories
 * inherit from. Loads objects from JSON files and stores them.
 */
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
// TODO: make singleton

public class Repository <contentObject> {

	static string baseFolderPath = "Assets/data/repositories/";
	private string repositoryFileName = "";
	private List<contentObject> contents;

	public Repository (string _repsitoryFolderName) {
		repositoryFileName = _repsitoryFolderName;
		contents = ReadDataFromJson();
	}

	public Repository (string _baseFolderPath, string _repositoryFolderName) {
		baseFolderPath = _baseFolderPath;
		repositoryFileName = _repositoryFolderName;
		ReadDataFromJson();
	}

	private List<contentObject> ReadDataFromJson () {
		List<contentObject> listFromData = new List<contentObject>();
		string contentsRaw = "";
		string filename = baseFolderPath + repositoryFileName;

		try {
			StreamReader reader = new StreamReader(filename, Encoding.Default);
			using (reader) {
				contentsRaw = reader.ReadToEnd();
				reader.Close();
			}
		} catch (IOException e) {
			Debug.LogError(e.Message);
		} catch (OutOfMemoryException e) {
			Debug.LogError(e.Message);
		} catch (Exception e) {
			Debug.LogError(e.Message);
		}

		contentObject[] contentArray = JsonArrayHelper.FromJson<contentObject>(contentsRaw);
		foreach (contentObject obj in contentArray) {
			listFromData.Add(obj);
		}

		return listFromData;
	}

	public List<contentObject> getContents() {
		return contents;
	}

}