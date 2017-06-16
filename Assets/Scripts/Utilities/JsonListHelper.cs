using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class JsonListHelper {
	public static List<T> GetListFromFilepath<T>(string filepath) {
		List<T> output = new List<T>();
		string contentsJson = "";

		try {
			StreamReader reader = new StreamReader(filepath, Encoding.Default);
			using (reader) {
				contentsJson = reader.ReadToEnd();
				reader.Close();
			}
		} catch (IOException e) {
			Debug.LogError(e.Message);
		} catch (OutOfMemoryException e) {
			Debug.LogError(e.Message);
		} catch (Exception e) {
			Debug.LogError(e.Message);
		}

		T[] contentArray = JsonArrayHelper.FromJson<T>(contentsJson);
		foreach(T obj in contentArray) {
			output.Add(obj);
		}

		return output;
	}
}