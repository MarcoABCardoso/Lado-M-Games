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
			tocar = false;
		}
		
		else if(parar == true){
			GetComponent<AudioSource>().Pause();
			parar = false;
		}
		
		
	
	}
}
