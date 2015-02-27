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
	
	void Start () {
	
	}
	
	
	void Update () {
	
		

		// Checa se esta no chao
		

		if (noChao && Input.GetKeyDown(PULO)) {
			rigidbody2D.velocity += new Vector2 (0f,4.1f);
			pulos++;
			if(pulos==2){
				pulos = 0;
				noChao = false;
			}
			
		}
		if (!noChao) {

		}
		if  (Input.GetKey(DIREITA)) {
			rigidbody2D.velocity = new Vector2 (5f, rigidbody2D.velocity.y);
			GetComponent<Animator>().SetBool("Correndo", true);
			transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
		}
		else if (Input.GetKey(ESQUERDA)) {
			rigidbody2D.velocity = new Vector2 (-5f, rigidbody2D.velocity.y);
			GetComponent<Animator>().SetBool("Correndo", true);
			transform.rotation = Quaternion.Euler(new Vector3(0f,180f,0f));
		}
		else {
			rigidbody2D.velocity = new Vector2 (0f, rigidbody2D.velocity.y);
			GetComponent<Animator>().SetBool("Correndo", false);
		}
	}
}
