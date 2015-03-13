using UnityEngine;
using System.Collections;

public class CenouraMusica : MonoBehaviour {

	GameObject musica;
	
	void Start(){
		
		musica = GameObject.Find("Musica de fundo");
	}
	
	void OnTriggerEnter2D(Collider2D other){
		musica.GetComponent<AudioSource>().pitch =- 0.8f;
		
	}
}
