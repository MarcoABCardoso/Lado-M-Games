using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	public string CardType;
	
	public void GenerateCard (string cardType){
	
		CardType = cardType;
		renderer.material.mainTexture = Resources.Load("Graphics/" + CardType) as Texture2D;
	}
	
}
 