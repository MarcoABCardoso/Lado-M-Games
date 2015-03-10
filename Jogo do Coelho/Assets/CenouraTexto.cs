using UnityEngine;
using System.Collections;

public class CenouraTexto : MonoBehaviour {

	public GameObject coelho;
	bool retangulo = false; //o retângulo com texto em cima do coelho
	public Texture2D preto; //nem é mais preto (é branco) mas eu tenho medo de mudar o nome disso e alguma coisa dar errado
	
	
	void OnTriggerEnter2D(Collider2D other){
		retangulo = true;
		
	}
	
	
	void OnGUI(){
		if(retangulo){
			GUI.Box (new Rect(coelho.transform.localPosition.x, 60,200,70),"\n TEXTO");
			GUI.skin.box.normal.background = preto;
			GUI.skin.box.normal.textColor = Color.black;
			
			GUI.skin.box.border = new RectOffset();
			Debug.Log("textoo");
			
		}	
	}
	
	
}
