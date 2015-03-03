using UnityEngine;
using System.Collections;

public class Cerca : MonoBehaviour {

	bool parou; //o coelho parou de tocar
	public GameObject cercas;
	
			
	void OnTriggerEnter2D(Collider2D other){
	
		Debug.Log ("ta tocando a cerca");
	
		//tem que fazer o texto desaparecer, não a cerca. eu li errado o que a maria escreveu, risos.
		Destroy(cercas);
	}
}
