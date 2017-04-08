using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {

	/*
	 * FIELDS
	 */
	private Vector2 vector = Vector2.zero;
	private Transform myTransform;
	private Collider2D myCollider;
	private bool clearOfSelf = false;
	// Settings
	private float speed;
	private float lethality = 1;

	/*
	 * PROPERTIES
	 */
	public Vector2 Vector { get; set; }

	/*
	 * INITIALIZATION
	 */
	public void Start () {
		myTransform = GetComponent<Transform>();
		myCollider = GetComponent<Collider2D>();
	} 
	public void Configure (Vector2 _vector, float _speed) {
		vector = _vector;
		speed = _speed;
	}
	
	/*
	 * METHODS
	 */
	void Update () {
		Go();
	}

	private void Go() {
		myTransform.Translate(vector.normalized * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (clearOfSelf) {
			if (collision.gameObject.tag == "Player") {
				collision.gameObject.GetComponent<Character>().Damage(lethality);
			}

			Destroy(gameObject);
		}
	}

	void OnTriggerExit2D () {
		clearOfSelf = true;
	}
}