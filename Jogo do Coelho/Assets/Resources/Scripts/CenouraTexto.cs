using UnityEngine;
using System.Collections;

public class CenouraTexto : MonoBehaviour {

	public GameObject GameManager;
	public GameObject coelho;
	public Texture2D preto; //nem é mais preto (é branco) mas eu tenho medo de mudar o nome disso e alguma coisa dar errado
	
	
	void Start(){
		GameManager = GameObject.Find("Game Manager");
	
	}
	
	
	void OnTriggerEnter2D(Collider2D other){
		if(GameManager.GetComponent<GameManager>().texto == false) {
			GameManager.GetComponent<GameManager>().preto = preto;
			GameManager.GetComponent<GameManager>().texto = true;
		}
		
		else if (GameManager.GetComponent<GameManager>().texto == true){
			GameManager.GetComponent<GameManager>().texto = false;
		}
		
		
	}
	
	

	
	
}
