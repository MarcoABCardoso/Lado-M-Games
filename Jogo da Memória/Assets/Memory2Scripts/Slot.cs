using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	
	void OnDrawGizmos(){
	
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position, new Vector3(3,0,4));
	
		Gizmos.color = Color.white;
		Gizmos.DrawCube(transform.position, new Vector3(3,0,4));
	} 
	 
}
