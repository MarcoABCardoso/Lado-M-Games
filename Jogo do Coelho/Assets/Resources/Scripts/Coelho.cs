
	using UnityEngine;
	using System.Collections;
	
	public class Coelho : MonoBehaviour {
		
		KeyCode DIREITA = KeyCode.RightArrow;
		KeyCode ESQUERDA = KeyCode.LeftArrow;
		KeyCode PULO = KeyCode.UpArrow;
		
		bool noChao;
		int pulos; //conta os pulos
		
		
		void OnCollisionEnter2D(Collision2D other){
			//Checa se está no chão
			noChao = true;
			Debug.Log("ta no chão");
			
		}
		
		
		void Update () {
			
			// Checa se esta no chao
			
			
			if (noChao && Input.GetKeyDown(PULO)) {
				GetComponent<Rigidbody2D>().velocity += new Vector2 (0f,4.1f);
				pulos++;
				if(pulos==1 ){
					pulos = 0;
					noChao = false;
				}
				
			} 
			if (!noChao) {
				
			}
			if  (Input.GetKey(DIREITA)) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (5f, GetComponent<Rigidbody2D>().velocity.y);
				GetComponent<Animator>().SetBool("Correndo", true);
				transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
			}
			else if (Input.GetKey(ESQUERDA)) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-5f, GetComponent<Rigidbody2D>().velocity.y);
				GetComponent<Animator>().SetBool("Correndo", true);
				transform.rotation = Quaternion.Euler(new Vector3(0f,180f,0f));
			}
			else {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, GetComponent<Rigidbody2D>().velocity.y);
				GetComponent<Animator>().SetBool("Correndo", false);
			}
		}
	}
	

