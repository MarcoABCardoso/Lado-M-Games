using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Audio : MonoBehaviour {

	
	public bool tocar = false;
	public bool parar = false;
	public bool pitch1 = false;
	
	
	void Start () {
	
	}
	
	//você clica e ele começa a tocar ou a parar a musica
	void Update () {
		if(tocar == true){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().pitch = 1;
			tocar = false;
		}
		
		else if(parar == true){
			GetComponent<AudioSource>().Pause();
			parar = false;
		}
		
		else if(pitch1 == true){
			GetComponent<AudioSource>().pitch = GetComponent<AudioSource>().pitch + 0.15f;
			pitch1 = false;
		}
		
		
	
	}
}
