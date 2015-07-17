using UnityEngine;
using System.Collections;

public class TirarSom : MonoBehaviour {

	public void OnMouseDown () {
		
		if(GetComponent<AudioSource>().isPlaying){
			GetComponent<AudioSource>().Stop();
		}
		else{
			GetComponent<AudioSource>().Play();
		}
		
		
	}
	
}
