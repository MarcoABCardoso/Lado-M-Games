using UnityEngine;
using System.Collections;

public class TaNaCerca : MonoBehaviour {

	public GameObject coelho;

	bool retangulo = false;
	int cont = 0; //ele conta quantas vezes ele encostou no triggerCollider antes ou depois da cerca
	
	void OnTriggerEnter2D(Collider2D other){
		if(cont==0){
			retangulo = true;
			cont++;
			Debug.Log (cont);
		}
		else{
			retangulo = false;
			cont = 0;
		}
	}
	
	void OnGUI(){
		if(retangulo){
			
			GUI.Box (new Rect(coelho.transform.localPosition.x, 60,200,70),"TEXTO");
			
		}	
	}


}
