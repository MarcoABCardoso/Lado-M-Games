/*		credits: xtase studios - http://xtasestudios.com/scripts		*/
using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {
	
	public int cardnumber;
	private Logic logic;
	private bool selected = false;
	
	// Use this for initialization
	void Start () {
		logic = Camera.main.GetComponent<Logic>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetMemorycard(Texture t, int number){
		renderer.materials[1].mainTexture = t;
		cardnumber = number;
	}
	
	public void Show(){
		if(!selected){
			selected = true;
			animation.Play("Flip_show");
			logic.CheckCards(this);
		}
	}

	public void Hide(){
		animation.Play("Flip_hide");
		selected = false;
	}
	
	public void RemoveCard(){
		animation.Play("Flip_hide");
		StartCoroutine("Remove");
	}
	IEnumerator Remove(){
		yield return new WaitForSeconds(.5f);
		Destroy(gameObject);
	}
}