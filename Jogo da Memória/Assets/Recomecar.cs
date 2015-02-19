using UnityEngine;
using System.Collections;

public class Recomecar : MonoBehaviour {

	public void OnMouseDown () {
		audio.Play();
		Application.LoadLevel(0);
	}
}
