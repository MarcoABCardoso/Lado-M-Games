using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject coelho;
	public Texture2D preto;
	public bool texto; //se tem o texto em cima do coelho (usado só pras cenouras por enquanto)


	void Start () {
		texto = false;
		coelho = GameObject.Find("Coelho");
	}
	
	void OnGUI(){
		if(texto){
			GUI.Box (new Rect(coelho.transform.localPosition.x, 60,200,70),"\n TEXTO");
			GUI.skin.box.normal.background = preto;
			GUI.skin.box.normal.textColor = Color.black;
			
			GUI.skin.box.border = new RectOffset();
			
		}	
	}
	
}
