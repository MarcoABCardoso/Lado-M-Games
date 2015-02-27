using UnityEngine;
using System.Collections;

public class Coelho : MonoBehaviour {

	KeyCode DIREITA = KeyCode.RightArrow;
	KeyCode ESQUERDA = KeyCode.LeftArrow;
	KeyCode PULO = KeyCode.UpArrow;

	bool noChao;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Checa se esta no chao
		Debug.Log(rigidbody2D.velocity);
		//if (rigidbody2D.velocity.y == 0f) {
			noChao = true;
		//}
		//else {
		//	noChao = false;
		//}

		if (noChao && Input.GetKeyDown(PULO)) {
			rigidbody2D.velocity += new Vector2 (0f,4.5f);
		}
		if (!noChao) {

		}
		if (noChao && Input.GetKey(DIREITA)) {
			rigidbody2D.velocity = new Vector2 (5f, rigidbody2D.velocity.y);
			GetComponent<Animator>().SetBool("Correndo", true);
			transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
		}
		else if (noChao && Input.GetKey(ESQUERDA)) {
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
