using UnityEngine;
using System.Collections;

public class Carta : MonoBehaviour {
	// Classe que representa as cartas do jogo da memoria

	public GameObject GameManager;
	public int Numero; // Numero indica a qual par a carta pertence

	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find("GameManager");
	}
	
	
	public void OnMouseDown () {
		/****************************************************************************************************
		 * Procedimento em caso de clique sobre carta:
		 * 
		 * Verifica se ja existe uma ou duas cartas viradas
		 * Coloca a carta em questao em uma lacuna disponivel do GameManager, se houver
		 * Vira a carta
		 ****************************************************************************************************/
		if (GameManager.GetComponent<GameManager>().Carta1 == null) {
			GameManager.GetComponent<GameManager>().Carta1 = gameObject;
			GetComponent<Animator>().SetTrigger("Vira");
		}
		else if (GameManager.GetComponent<GameManager>().Carta2 == null) {
			GameManager.GetComponent<GameManager>().Carta2 = gameObject;
			GetComponent<Animator>().SetTrigger("Vira");
		}
	}
}
