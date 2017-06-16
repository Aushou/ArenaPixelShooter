using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class Translator : MonoBehaviour {
	// CONFIG
	// TODO: Get this from a config file
	public string folderPath = "/data/i18n/";
	public string language = "EN";
	// VALUES
	private Dictionary<string, string> languageDictionary;

	/*
	 * INITIALIZATION
	 */
	void Start() {
		ReadAndConstructDictionary();
	}

	// TODO: Consider moving this to JsonListHelper or other utility class
	private void ReadAndConstructDictionary() {
		languageDictionary = new Dictionary<string, string>();
		string rawJson = "";
		string filepath = Application.dataPath + folderPath + "test_" + language + ".json";
		try {
			StreamReader reader = new StreamReader(filepath, Encoding.Default);
			using (reader) {
				rawJson = reader.ReadToEnd();
				reader.Close();
			}
		} catch (IOException e) {
			Debug.LogError(e.Message);
		} catch (OutOfMemoryException e) {
			Debug.LogError(e.Message);
		} catch (Exception e) {
			Debug.LogError(e.Message);
		}

		TranslatedString[] arrayContents = JsonArrayHelper.FromJson<TranslatedString>(rawJson);
		foreach(TranslatedString pair in arrayContents) {
			languageDictionary.Add(pair.key, pair.value);
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
		if (languageDictionary != null && languageDictionary.TryGetValue(key, out value)) {
			return value;
		} else {
			Debug.LogError(gameObject.name +
				".getLineByKey(" +
				key +
				"): languageDictionary not defined!");
		}

		return "error";
	}

	/*
	 * DEBUG
	 */
	private void testLanguageDictionary() {
		foreach(KeyValuePair<string, string> entry in languageDictionary) {
			Debug.Log("Key: " + entry.Key + ", Value: " + entry.Value);
		}
	}

	[Serializable]
	private class TranslatedString {
		public string key;
		public string value;

		public TranslatedString(string _key, string _value) {
			key = _key;
			value = _value;
		}
	}
}
