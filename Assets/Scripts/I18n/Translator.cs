using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

public class Translator : MonoBehaviour {
	/*
	 * VARIABLES
	 */
	// CONFIG
	public string folderPath = "data/I18n/";
	public string language = "EN";
	// VALUES
	private Dictionary<string, string> languageDictionary;

	/*
	 * INITIALIZATION
	 */
	void Start() {
		constructDictionary();
	}

	private void constructDictionary() {
		/* INPUT: none
		 * OUTPUT: none
		 * DESCRIPTION: reads json from file and populates languageDictionary with key/value pairs based on JSON in file
		 */
		languageDictionary = new Dictionary<string, string>();
		JsonData json = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + folderPath + "test_" + language + ".json"));
		for (int i = 0; i < json.Count; i++) {
			string key = (string)json[i]["key"];
			string value = (string)json[i]["value"];
			languageDictionary.Add(key, value);
		}
	}

	/*
	 * METHODS
	 */
	public string getLineByKey(string key) {
		/* INPUT: (string)key
		 * OUTPUT: (string)value
		 * DESCRIPTION: Gets value from languageDictionary associated with
		 * given key
		 */
		string value = "";
		if (languageDictionary != null) {
			value = languageDictionary[key];
		} else { Debug.LogError(gameObject.name + ".getLineByKey(" + key + "): languageDictionary not defined!"); }
		
		return value;
	}

	/*
	 * DEBUG
	 */
	private void testLanguageDictionary() {
		foreach(KeyValuePair<string, string> entry in languageDictionary) {
			Debug.Log("Key: " + entry.Key + ", Value: " + entry.Value);
		}
	}
}
