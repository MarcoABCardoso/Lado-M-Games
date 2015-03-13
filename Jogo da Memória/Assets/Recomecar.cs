using UnityEngine;
using System.Collections;

public class Recomecar : MonoBehaviour {

	public void OnMouseDown () {
		GetComponent<AudioSource>().Play();
		Application.LoadLevel(0);
	}
}
