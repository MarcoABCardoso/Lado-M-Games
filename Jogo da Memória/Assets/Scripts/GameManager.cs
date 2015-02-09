using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	// Classe com uma unica instancia, que controla os aspectos mais gerais do jogo
	GameObject Cartas; // GameObject que contem todas as cartas
	public GameObject Carta1; // Primeira carta virada
	public GameObject Carta2; // Segunda carta virada
	GameObject Sombra; // Um retangulao na frente que serve pra escurecer a tela
	public GUISkin MyGUI;

	string descriçao = "Feministeia e uma pessoa mto top seriao linda ela luta por direitos like crazy";
	string nome = "Feministeia Daorerson";
	float timer; // Temporizador, faz com que eventos demorem para acontecer
	bool errado; // As cartas encontradas nao formam par
	bool certo; // As cartas encontradas formam par
	bool continuar;
	
	//int cont = 0;
	
	// Use this for initialization
	void Start () {
		Sombra = GameObject.Find("Sombra");
		timer = 0;
	}
	
	
	// Update is called once per frame
	void Update () {
		/**************************************************
		 * Verificaçao do par encontrado:
		 * 
		 * Verifica se ha cartas nos espaços Carta1 e Carta2
		 * Se as cartas tem o mesmo Numero, elas formam par
		 * Caso contrario, nao formam
		 **************************************************/
		if (Carta1 != null && Carta2 != null && timer == 0) {
			timer = 1;
			if (Carta1.GetComponent<Carta>().Numero == Carta2.GetComponent<Carta>().Numero) {
				certo = true;
			}
			else {
				errado = true;
			}
		}
		
		

		/**************************************************
		 * Procedimento em caso de erro:
		 * 
		 * Verifica se o procedimento esta em curso (errado = True)
		 * Reduz o timer
		 * Quando timer vai abaixo de zero:
		 * -Crava ele no zero
		 * -Termina o processo
		 * -Desvira as cartas
		 * -Abre os espaços Carta1 e Carta2
		 **************************************************/
		if (errado) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				timer = 0;
				errado = false;
				Carta1.GetComponent<Animator>().SetTrigger("Vira");
				Carta2.GetComponent<Animator>().SetTrigger("Vira");
				Carta1 = null;
				Carta2 = null;
			}
		}

		/**************************************************
		 * Procedimento em caso de acerto:
		 * 
		 * Verifica se o procedimento esta em curso (certo = true)
		 * Reduz o timer
		 * Quando o timer vai abaixo de zero:
		 * -Crava ele no zero
		 * -Termina o processo
		 * -Deleta hitboxes (cliques sobre as cartas nao funcionam mais)
		 * -Abre os espaços Carta1 e Carta2
		 * FALTA INCLUIR OUTROS EVENTOS NESSA PARTE!!
		 **************************************************/
		 
		//int vert = Carta1.GetComponent<Carta>().Numero;
		 
		if (certo) {
			timer -= Time.deltaTime;
			Sombra.GetComponent<SpriteRenderer>().color = new Color(0,0,0,(1f-timer)/2f);
			Sombra.GetComponent<BoxCollider2D>().enabled = true;
			if (timer <= 0) {
				timer = 0;
				//certo = false;
				audio.Play();
				//Instantiate(Carta1.GetComponent<Carta>().Explosao, Carta1.transform.position, Carta1.transform.rotation);
				DestroyImmediate(Carta1);
				//Instantiate(Carta2.GetComponent<Carta>().Explosao, Carta2.transform.position, Carta2.transform.rotation);
				DestroyImmediate(Carta2);
				Carta1 = null;
			}
			//Application.LoadLevel(2);
		}
	}

	void OnGUI () {

		MyGUI.label.fontSize = Screen.height*1/20;
		MyGUI.button.fontSize = Screen.height*1/20;
		MyGUI.textArea.fontSize = Screen.height*1/20;
		GUI.skin = MyGUI;

		if (certo) {
			// name = DEPENDE DO NUMERO DAS CARTAS
			// descriçao = TAMBEM DEPENDE
			GUI.Label (new Rect (Screen.width*5/8, Screen.height*1/4 - timer*500, Screen.width, Screen.height), nome);
			GUI.TextArea (new Rect (0, Screen.height*1/2 + timer*500, Screen.width, Screen.height*1/2), descriçao);
			if (GUI.Button (new Rect (Screen.width*3/8, Screen.height*3/8, Screen.width*1/4, Screen.width*1/16), "AMO/SOU")) {
				certo = false;
				Sombra.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
				Sombra.GetComponent<BoxCollider2D>().enabled = true;
			}
		}
	}
	
}
