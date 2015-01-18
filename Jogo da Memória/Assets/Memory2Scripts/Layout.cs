using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Layout {

	public List<string> layoutNames = new List<string>();
	public List<Slot> slots = new List<Slot>() ;
	
	public GameObject GetRandomLayout(){
		return GetLayoutFromIndex(Random.Range(0, layoutNames.Count));
	}
	
	public GameObject GetLayoutFromName (string s){
		return GetLayoutFromIndex(layoutNames.IndexOf(s));
		 
	}
	
	public GameObject GetLayoutFromIndex (int index){
		GameObject resource = Resources.Load("Prefabs/" + layoutNames[index]) as GameObject ;
		GameObject go = GameObject.Instantiate(resource, Vector3.zero, Quaternion.identity) as GameObject;
		
		foreach(Slot slot in go.GetComponentsInChildren<Slot>()){
			slots.Add(slot);
		}
		
		return go;
	}
	
}
