/*		credits: xtase studios - http://xtasestudios.com/scripts		*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shuffle : MonoBehaviour {

	public GameObject memorycard;
	public Texture[] cards;
	
	private List<Card> cardslist = new List<Card>();
	
	class Card{
		public int number;
		public Texture texture;
		
		public Card(int n, Texture t){
			number = n;
			texture = t;
		}
	}
	
	// Use this for initialization
	void Start () {
		for(int i=0; i<cards.Length; i++){
			cardslist.Add(new Card(i, cards[i]));
			cardslist.Add(new Card(i, cards[i]));
		}
		
		if(cards.Length > 0)
			ShuffleCards();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ShuffleCards(){
		int nrofcards = cardslist.Count;
		Camera.main.GetComponent<Logic>().SetSetsOfCards(cards.Length);
		List<Card> temp = new List<Card>();
		
		for(int i =0; i<nrofcards; i++){
			int random = Random.Range(0, nrofcards-i);
			temp.Add(cardslist[random]);
			cardslist.RemoveAt(random);
		}
		
		cardslist = temp;
		SpawnCards();
	}
	
	void SpawnCards(){
		int cardsinrow = 4;
		int cardsincolumn = cardslist.Count/cardsinrow;
		if(cardslist.Count % cardsinrow > 0)
			cardsincolumn += 1;
		float spacebetweencards = .2f;
		
		for(int i=0; i<cardslist.Count; i++){
			GameObject mc = Instantiate(memorycard, new Vector3((i%cardsinrow+(i%cardsinrow*spacebetweencards))-(cardsinrow/2f)+spacebetweencards, 0, (i/cardsinrow+(i/cardsinrow*spacebetweencards))-(cardsincolumn/2f)+spacebetweencards), memorycard.transform.rotation) as GameObject;
			mc.GetComponentInChildren<MemoryCard>().SetMemorycard(cardslist[i].texture, cardslist[i].number);
		}
	}
}
