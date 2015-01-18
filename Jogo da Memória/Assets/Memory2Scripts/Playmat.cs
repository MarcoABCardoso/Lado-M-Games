using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Playmat : MonoBehaviour {

	public GameObject cardPrefab;
	public Layout layout;
	public GameObject board;
	public List<Card> cards = new List<Card>() ;
	
	void Start(){
		GameSettings.Instance().SetDifficulty(GameSettings.GameDifficulty.Medium);
		CreateLayout();
//		CreateCardsFromLayout(); 
		CreateCardTypes();
	}
	
	void CreateLayout(){
		board = layout.GetRandomLayout ();
	}
	
	/*
	void CreateCardsFromLayout(){   
		foreach(Slot s in layout.slots){ 
			GameObject go = GameObject.Instantiate(cardPrefab,s.transform.position, Quaternion.Euler(0,-90,270)) as GameObject;
			go.transform.parent = s.transform;  
			cards.Add(go.GetComponents<Card>());
		}
	}
	*/
	
	void CreateCardTypes(){
		for(int i=0; i< cards.Count/2;i++){
			Card c1 = cards[i];
			Card c2 = cards[cards.Count/2 - 1 - i];
			string type = GameSettings.Instance().GetRandomType(); 
			c1.GenerateCard(type);
			c2.GenerateCard(type);
			
		}
	}
	
}
