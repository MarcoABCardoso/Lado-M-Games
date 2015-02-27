using UnityEngine;
using System.Collections;

public class Cogumelos : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Destroy(gameObject.collider);
	}
}
