using UnityEngine;
using System.Collections;

public class Cenouras : MonoBehaviour {

	void Update(){
		
		
		Debug.Log("cenoura");
		transform.Rotate(Vector3.forward * Time.deltaTime * 50, Space.World);
	
	}

	void OnTriggerEnter2D (Collider2D other){
	
		Destroy(gameObject);
	}
}
