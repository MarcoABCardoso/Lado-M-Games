using UnityEngine;
using System.Collections;

public class Coelho2 : MonoBehaviour {

	KeyCode DIREITA = KeyCode.RightArrow;
	KeyCode ESQUERDA = KeyCode.LeftArrow;
	KeyCode PULO = KeyCode.UpArrow;
	


	// Use this for initialization
	void Start () {
	
		GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
