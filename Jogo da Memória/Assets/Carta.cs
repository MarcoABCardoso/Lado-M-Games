﻿using UnityEngine;
using System.Collections;

public class Carta : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		GetComponent<Animator>().SetTrigger("Vira");
	}
}
