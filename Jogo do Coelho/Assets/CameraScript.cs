using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform Coelho;
	Vector3 offset;
	
	void Start(){

		Coelho = GameObject.Find("Coelho").transform;
		offset = new Vector3 (2, 2, 0);
	}
	
	void Update(){
		
		transform.position += (Coelho.position-transform.position+offset)*Time.deltaTime;
		transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
	}
}
