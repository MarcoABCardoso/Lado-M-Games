using UnityEngine;
using System.Collections;

public class Cenouras : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
	
		Destroy(gameObject);
	}
}
