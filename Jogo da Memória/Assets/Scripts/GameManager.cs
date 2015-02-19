using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour {
	// Classe com uma unica instancia, que controla os aspectos mais gerais do jogo
	GameObject Cartas; // GameObject que contem todas as cartas
	public GameObject Carta1; // Primeira carta virada
	public GameObject Carta2; // Segunda carta virada
	GameObject Sombra; // Um retangulao na frente que serve pra escurecer a tela
	public GUISkin MyGUI;
	public Font FonteTitulo;
	public Font FonteTexto;
	public TextAsset Textos;

	string[] pacotes;
	string[] linhas;
	string descriçao = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam eget ligula eu lectus lobortis condimentum. Aliquam nonummy auctor massa. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla at risus. Quisque purus magna, auctor et, sagittis ac, posuere eu, lectus. Nam mattis, felis ut adipiscing.";
	string nome = "Fulana Beltrana";
	string corrente1 = "Feminismo";
	string corrente2 = "loucao";
	float timer; // Temporizador, faz com que eventos demorem para acontecer
	bool errado; // As cartas encontradas nao formam par
	bool certo; // As cartas encontradas formam par
	bool continuar;
	
	//int cont = 0;
	
	// Use this for initialization
	void Start () {
		Sombra = GameObject.Find("Sombra");
		pacotes = Regex.Split(Textos.text, "\n\r\n\r\n");
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
		if (Carta1 != null && Carta2 != null && timer == 0 && !certo) {
			if (Carta1.GetComponent<Carta>().Numero == Carta2.GetComponent<Carta>().Numero) {
				certo = true;
				timer = 2;
				audio.Play();
				// Define os textos
				linhas = Regex.Split(pacotes[Carta1.GetComponent<Carta>().Numero-1],"\n\r\n");
				corrente1 = linhas[0];
				descriçao = linhas[1];
				nome = linhas[2];
			}
			else {
				errado = true;
				timer = 1;
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
		 * Quando o timer vai abaixo de zero:* -Crava ele no zero
		 * -Termina o processo
		 * -Deleta hitboxes (cliques sobre as cartas nao funcionam mais)
		 * -Abre os espaços Carta1 e Carta2
		 * FALTA INCLUIR OUTROS EVENTOS NESSA PARTE!!
		 **************************************************/
		 
		//int vert = Carta1.GetComponent<Carta>().Numero;
		 
		if (certo) {

			if (timer > 0) {
				timer -= Time.deltaTime;
			}
			if (timer < 1 && timer > 0) {
				Carta1.transform.FindChild("Carta (frente)").GetComponent<SpriteRenderer>().sortingOrder = 11;
				Carta2.transform.FindChild("Carta (frente)").GetComponent<SpriteRenderer>().sortingOrder = 11;
				Sombra.GetComponent<SpriteRenderer>().color = new Color(0,0,0,(1f-timer)/2f);
				Sombra.GetComponent<BoxCollider2D>().enabled = true;
				Carta1.transform.position += (new Vector3(0f,3f,0f) - Carta1.transform.position)*Time.deltaTime*10;
				Carta2.transform.position += (new Vector3(0f,3f,0f) - Carta2.transform.position)*Time.deltaTime*10;
			}
			if (timer < 0) {
				timer = 0;
			}
			//Application.LoadLevel(2);
		}
	}

	void OnGUI () {

		MyGUI.label.fontSize = Screen.height*1/20;
		MyGUI.button.fontSize = Screen.height*1/20;
		MyGUI.textArea.fontSize = Screen.height*1/30;
		GUI.skin = MyGUI;

		if (certo) {

			GUI.skin.font = FonteTitulo;
			float aux = MyGUI.label.CalcSize(new GUIContent(corrente1)).x;
			GUI.Label (new Rect (Screen.width*5/8, Screen.height*1/8 - timer*500, Screen.width, Screen.height), corrente1);
			/*
			MyGUI.label.fontSize = 1;
			while (MyGUI.label.CalcSize(new GUIContent(corrente2)).x < aux) {
				MyGUI.label.fontSize += 1;
			}
			GUI.skin = MyGUI;
			GUI.Label (new Rect (Screen.width*5/8, Screen.height*1/8 + aux/2 - timer*500, Screen.width, Screen.height), corrente2);
			*/
			MyGUI.label.fontSize = Screen.height*1/20;
			GUI.Label (new Rect (Screen.width*3/16, Screen.height*1/8 - timer*500, Screen.width, Screen.height), nome);
			if (timer == 0 && GUI.Button (new Rect (Screen.width*3/8, Screen.height*3/8, Screen.width*1/4, Screen.width*1/16), "Continuar")) {
				certo = false;
				Sombra.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
				Sombra.GetComponent<BoxCollider2D>().enabled = true;
				//Instantiate(Carta1.GetComponent<Carta>().Explosao, Carta1.transform.position, Carta1.transform.rotation);
				DestroyImmediate(Carta1);
				//Instantiate(Carta2.GetComponent<Carta>().Explosao, Carta2.transform.position, Carta2.transform.rotation);
				DestroyImmediate(Carta2);
			}
			GUI.skin.font = FonteTexto;
			GUI.TextArea (new Rect (0, Screen.height*1/2 + timer*500, Screen.width, Screen.height*1/2), descriçao);
		}
		else {
			Sombra.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
	
}
