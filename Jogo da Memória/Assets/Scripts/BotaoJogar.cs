using UnityEngine;
using System.Collections;

public class BotaoJogar : MonoBehaviour {
	
	public void OnMouseDown () {
		audio.Play();
		Application.LoadLevel(1);
	}
}
