using UnityEngine;
using System.Collections;

public class Cogumelos : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		
		other.GetComponent<AudioSource>().Play();
		Destroy(gameObject);
	}
}
