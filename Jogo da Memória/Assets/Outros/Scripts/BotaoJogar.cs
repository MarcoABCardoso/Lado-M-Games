using UnityEngine;
using System.Collections;

public class BotaoJogar : MonoBehaviour {

	//Isso é pra ir pro jogo quando você clica em 'jogar'
	
	public void OnMouseDown () {
		audio.Play();
		Application.LoadLevel(1);
	}
	
}
