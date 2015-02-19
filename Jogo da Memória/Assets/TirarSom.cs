using UnityEngine;
using System.Collections;

public class TirarSom : MonoBehaviour {

	public void OnMouseDown () {
		
		if(audio.isPlaying){
			audio.Stop();
		}
		else{
			audio.Play();
		}
		
		
	}
	
}
