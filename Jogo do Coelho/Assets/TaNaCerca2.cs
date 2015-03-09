using UnityEngine;
using System.Collections;

public class TaNaCerca2 : MonoBehaviour {

	//O texto aparece assim que o coelho tocar na cerca e desaparece 2s depois que o coelho sair da cerca

	public GameObject coelho;
	bool retangulo = false; //o retângulo com texto em cima do coelho
	bool saiu = false; //o coelho saiu da cerca/outra coisa
	float Timer = 0;
	bool setTimer = false;

	void Update(){
		if(setTimer){
			Timer += Time.deltaTime;
		}
		
		if(saiu == true && Timer>= 1.5){
			retangulo = false;
		}
		
	}
	
			
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("o coelho está em cima da cerca");
		saiu = false;
		retangulo = true;
		setTimer = true;
		Timer = 0;
	}
	
	void OnCollisionExit2D(Collision2D other){
		saiu = true;
	}

	
	void OnGUI(){
		if(retangulo){
			GUI.Box (new Rect(coelho.transform.localPosition.x, 60,200,70),"TEXTO");
			
		}	
	}
}
