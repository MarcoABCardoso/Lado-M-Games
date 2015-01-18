/*		credits: xtase studios - http://xtasestudios.com/scripts		*/
using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) ){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
				if(hit.transform.GetComponent<MemoryCard>() != null){
					hit.transform.GetComponent<MemoryCard>().Show();
				}
		}
	}
}
