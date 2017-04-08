using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Camera myCamera;
	public float normalSize = 5;

	public bool following = false;
	public Transform followTargetTransform;
	private Transform myTransform;

	public Transform FollowTargetTransform { get; set; }

	// Use this for initialization
	void Start () {
		myCamera = GetComponent<Camera>();
		myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(following) {
			Follow(followTargetTransform);
		}
	}

	private void Follow(Transform followTargetTransform) {
		myTransform.position = followTargetTransform.position + new Vector3(0, 0, -10);
	}

	public void ToggleFollowing() {
		following = !following;
	}
	public void ToggleFollowing(bool desiredState) {
		following = desiredState;
	}

	public void StartPlayZoom() {
		StartCoroutine("PlayZoom");
	}

	IEnumerator PlayZoom() {
		for (float f = myCamera.orthographicSize; f >= normalSize; f -= 0.5f) {
			myCamera.orthographicSize = f;
			yield return null;
		}
	}
}
