﻿using UnityEngine.UI;
using UnityEngine;

public class TranslationHelper : MonoBehaviour {

	/*
	 * MEMBERS
	 */
	private TranslatorService translatorDictionary;
	private string translationKey;
	private Text myDisplay;

	/*
	 * MONOBEHAVIOR
	 */
	void Start () {
		Gets();
		BuildTranslationKey();
		myDisplay.text = GetTextValueFromTranslator();
	}
	void Update() {
		if(myDisplay.text == "") {
			myDisplay.text = GetTextValueFromTranslator();
		}
	}

	/*
	 * METHODS
	 */
	void Gets() {
		// DESCRIPTION: Get references to external objects
		translatorDictionary = TranslatorService.Instance;
		myDisplay = GetComponent<Text>();
	}

	void BuildTranslationKey() {
		// DESCRIPTION: Build translation key from object and parents names
		GameObject currObject = gameObject;
		translationKey = "";

		while (currObject.transform.parent != null) {
			// While not looking at the top UI object
			if(translationKey == "") {
				// Don't include period on first pass
				translationKey = currObject.name;
			} else {
				// Add parent name and period to front of string
				translationKey = currObject.name + "." + translationKey;
			}

			// Get next parent up
			currObject = currObject.transform.parent.gameObject;
		}
	}
	
	string GetTextValueFromTranslator() {
		/* OUTPUT: (string)displayText
		 * DESCRIPTION: Get display text from translator object
		 */
		string displayText = "";
		displayText = translatorDictionary.getLineByKey(translationKey);
		return displayText;
	}
	
	
}
