using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour {
	// Classe com uma unica instancia, que controla os aspectos mais gerais do jogo
	GameObject Cartas;
	public GameObject Carta1;
	public GameObject Carta2;
	GameObject Sombra;
	public GUISkin MyGUI;
	public Font FonteTitulo;
	public Font FonteTexto;

	string descriçao1 = "Teste çã";
	string nome = "Fulana Beltrana";
	string corrente1 = "Feminismo";
	string corrente2 = "loucao";
	string descriçao2 = "Linda ela";
	string textao;
	float timer;
	bool errado;
	bool certo;
	bool continuar;
	bool acabou;
	int cont = 0;
	
	
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
		if (Carta1 != null && Carta2 != null && timer == 0 && !certo) {
			if (Carta1.GetComponent<Carta>().Numero == Carta2.GetComponent<Carta>().Numero) {
				certo = true;
				timer = 2;
				GetComponent<AudioSource>().Play();
				// Define os textos
				if (Carta1.GetComponent<Carta>().Numero == 1) {
					corrente1 = "Feminismo";
					corrente2 = "Radical";
					descriçao1 = "\tO feminismo considerado como radical é aquele que delimita seu espaço como exclusivamente feminino: não há diálogo com homens, muito menos espaço de fala. Elas atribuem exclusivamente aos homens a responsabilidade pelos problemas de gênero da sociedade e defendem, inclusive, a segregação entre homens e mulheres em determinados espaços e debates. Alguns grupos dentro do radfem se posicionam contra os relacionamentos heterossexuais e a adoção de hábitos tidos como imposições do patriarcado, como a depilação.\n\tSeu campo de luta se dá exclusivamente nas questões relacionadas exclusivamente feminino. Alguns grupos, inclusive, não defendem, por exemplo, os direitos trans, por acreditarem que a própria ideia de transexualidade reforçaria estereótipos de gênero. Para as feministas radicais, são necessárias mudanças políticas que resultem não em inclusão, mas sim em revolução.";
					nome = "Mary Daly";
					descriçao2 = "\tUma das principais personagens da corrente radical do feminismo, Mary era filósofa, teóloga e professora acadêmica. Suas aulas, ministradas na Universidade de Boston, eram proibidas por Mary aos alunos homens. Acreditava que um passo importante na evolução do planeta seria a redução da população de machos e chamava a transexualidade de “fenômeno Frankenstein”.";
				}
				if (Carta1.GetComponent<Carta>().Numero == 2) {
					corrente1 = "Feminismo";
					corrente2 = "Cultural";
					descriçao1 = "\tO feminismo cultural, apesar de nascido do feminismo radical, diverge desde por acreditar que a oposição entre os sexos não parte de questões biológicas, mas sim sócio-culturais.\n\tO feminismo cultural  parte da valorização de características que, para suas seguidoras, são adjetivos naturalmente femininos, porém subestimados na sociedade, como a solidariedade, e que fariam com que a mulher estivesse em uma posição de superioridade em relação ao homem. Porém, com esse destaque para qualidades que caracterizariam a personalidade feminina, as integrantes do feminismo cultural também promovem uma distinção entre o sexo feminino e o masculino.";
					nome = "Linda Martín Alcoff";
					descriçao2 = "\tLinda é professora de Filosofia na faculdade de Hunter nos Estados Unidos. Além de dar palestras sobre a importância do feminismo cultural em diversas universidades da Ivy League (conjunto de universidades americanas prestigiadas), ela também escreveu uma série de livros focados na identidade social de gênero, raça, política e violência sexual.";
				}
				if (Carta1.GetComponent<Carta>().Numero == 3) {
					corrente1 = "Transfeminismo";
					corrente2 = "";
					descriçao1 = "\tO transfeminismo é uma vertente voltada para o debate e a luta contra a opressão heteronormativa da sociedade, ou seja, que diz respeito às questões da transgeneridade. Assim como as outras, esta vertente se pauta na libertação da mulher dos grilhões patriarcais, mas presta uma atenção especial às mulheres que nem sempre são tratadas como tais simplesmente por possuírem aspectos físicos que seriam “indignos” de uma mulher “real” (por não possuírem uma vagina ou seios, por exemplo).\n\tGrande parte da luta transfeminista está em desconstruir a transfobia intrínseca à sociedade moderna e garantir os direitos das mulheres trans* de serem tratadas de forma digna e condizente com o que se sentem mais confortáveis.";
					nome = "Sylvia Rae Rivera";
					descriçao2 = "\tSylvia foi uma travesti americana que militou pelo transfeminismo nos anos 60, tendo como marco de sua militância sua participação nos conflitos de Stonewall (conjunto manifestações e embates violentos entre a militância gay e trans* com a polícia de Nova Iorque). Rivera também é responsável pela criação da fundação Street Transvestite (S.T.A.R.), dedicada a ajudar jovens travestis moradoras de rua.";
				}
				if (Carta1.GetComponent<Carta>().Numero == 4) {
					corrente1 = "Feminismo";
					corrente2 = "Liberal";
					descriçao1 = "\tO feminismo liberal acredita na igualdade de gênero, e não na superioridade de um sexo em relação ao outro. Como uma das principais diferenças em relação a outras vertentes do feminismo, está o fato de que as feministas liberais não vêm os homens como inimigos, mas sim como possíveis aliados na luta pela igualdade de gênero. O movimento acredita que a igualdade das mulheres em relação aos homens na sociedade partiria do respeito deles em relação às atitudes e escolhas delas.\n\tEntre as causas pelas quais luta o feminismo liberal, está o fim da discriminação acadêmica e profissional em relação às mulheres, mudanças legislativas que garantam igualdade de direitos em relação aos homens diante do Estado, o fim do assédio sexual e da violência doméstica, entre outros tópicos.";
					nome = "Betty Friedan";
					descriçao2 = "\tBetty Friedan foi a autora da obra “A Mística Feminina”, um dos livros de cabeceira do movimento feminista. Betty analisou o papel das mulheres no sistema capitalista, depois de perceber que muitas mulheres, quando restritas às tarefas domésticas, passavam a desenvolver transtornos psicológicos, como a depressão.";
				}
				if (Carta1.GetComponent<Carta>().Numero == 5) {
					corrente1 = "Feminismo";
					corrente2 = "Interseccional";
					descriçao1 = "\tO feminismo intersecional passou a ter esse nome com a criação do termo, em 1989, por Kimberlé Crenshaw, professora norte-americana que aproveitou o conceito dessa militância para cunhar uma nova forma de se referir a ela. Em sua perspectiva, e como é comumente mais aceito entre as seguidoras dessa vertente, a intersecionalidade é “A visão de que as mulheres experimentam a opressão em configurações variadas e em diferentes graus de intensidade”. Dessa forma, o feminismo intersecional compreende diferentes focos de luta por diferentes mulheres, uma vez que suas vivências são únicas e cada uma se inclui em seus parâmetros pessoais de opressão.\n\tAlém disso, os “padrões culturais de opressão”  não só estariam interligados, como também estão unidos e influenciados uns pelos outros. Seriam exemplos de diferentes focos que se interrelacionam as militâncias de raça, gênero, classe, capacidades físicas/mentais, etnia, dentre outros.";
					nome = "Kimberlé Crenshaw";
					descriçao2 = "\tKimberlé é uma mulher negra e americana nascida durante os anos 50 e que se especializou nas questões raciais e de gênro em sua militância. No campo profissional, Kimberlé é uma professora bastante reconhecida nas universidades de UCLA - School of Law e Columbia Law School.";
				}
				if (Carta1.GetComponent<Carta>().Numero == 6) {
					corrente1 = "Feminismo";
					corrente2 = "Negro";
					descriçao1 = "\tComo o próprio nome já introduz, essa vertente constitui um movimento social protagonizado por mulheres negras, com o objetivo de promover e trazer visibilidade às suas pautas e reivindicar seus direitos. A necessidade da criação de um movimento específico para as pautas raciais dentro do feminismo surge da própria segregação que muitas mulheres negras sofrem em outras vertentes, sendo silenciadas por pessoas brancas e não tendo o espaço de fala que merecem nessas questões. No Brasil, seu início se deu no final da década de 1970, quando as primeiras feministas negras perceberam que não só o próprio Movimento Negro tinha sua face sexista, como também o Movimento Feminista tinha sua face racista, preterindo as discussões de recorte racial e privilegiando as pautas que contemplavam somente as mulheres brancas.";
					nome = "Sueli Carneiro";
					descriçao2 = "\tDoutora em Educação pela Universidade de São Paulo (USP), Sueli é também fundadora do conhecido “Geledés – Instituto da Mulher Negra”, a primeira organização declaradamente voltada ao feminismo negro de forma independente de São Paulo. Teórica da questão da mulher negra, criou o único programa brasileiro de orientação na área de saúde física e mental específico para mulheres negras, onde mais de trinta mulheres são atendidas semanalmente por psicólogos e assistentes sociais.";
				}
				textao = descriçao1;
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
		}
		
		else if (acabou){
			Application.LoadLevel(2);
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

			if (corrente2 != "") {
				MyGUI.label.fontSize = 1;
				while (MyGUI.label.CalcSize(new GUIContent(corrente2)).x < aux) {
					MyGUI.label.fontSize += 1;
				}
				GUI.skin = MyGUI;
				GUI.Label (new Rect (Screen.width*5/8, Screen.height*1/8 + aux/2 - timer*500, Screen.width, Screen.height), corrente2);
			}

			MyGUI.label.fontSize = Screen.height*1/20;
			GUI.Label (new Rect (Screen.width*3/16, Screen.height*1/8 - timer*500, Screen.width, Screen.height), nome);
			if (timer == 0 && GUI.Button (new Rect (Screen.width*3/8, Screen.height*3/8, Screen.width*1/4, Screen.width*1/16), "Continuar")) {
				cont++;
				certo = false;
				Sombra.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
				Sombra.GetComponent<BoxCollider2D>().enabled = true;
				DestroyImmediate(Carta1);
				DestroyImmediate(Carta2);
			}
			if (timer == 0 && GUI.Button (new Rect (Screen.width*5/8, Screen.height*3/8, Screen.width*1/4, Screen.width*1/16), "A Vertente")) {
				textao = descriçao1;
			}
			if (timer == 0 && GUI.Button (new Rect (Screen.width*1/8, Screen.height*3/8, Screen.width*1/4, Screen.width*1/16), "A Personagem")) {
				textao = descriçao2;
			}

			if(cont == 6){
				acabou = true;
			}
				
			
			GUI.skin.font = FonteTexto;
			GUI.TextArea (new Rect (0, Screen.height*1/2 + timer*500, Screen.width, Screen.height*1/2), textao);
		}
		else {
			Sombra.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
	
}
