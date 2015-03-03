using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform Coelho;
	public Vector3 offset = new Vector3 (2,2,0);
	
	void Start(){

		Coelho = GameObject.Find("Coelho").transform;
	}
	
	void Update(){
		
		transform.position += (Coelho.position-transform.position+offset)*Time.deltaTime;
		transform.position = new Vector3(transform.position.x, Coelho.transform.position.y + 1.8f, -10f);
	}
}
