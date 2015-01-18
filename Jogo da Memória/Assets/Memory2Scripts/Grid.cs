using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


[ExecuteInEditMode]
public class Grid : MonoBehaviour {

	public bool createGrid = false;
	public bool clearGrid = false;
	public bool register = false;
	public bool save = false; 
	
	public List<GameObject> slots = new List<GameObject>();
	public enum GridType{
	XbyY, ClickToRemove
	}
	public GridType gridType;
	public enum Orientation{
	TopLeft
	}
	public Orientation orientation;
	public Vector3 StartingPosition = new Vector3();
	public int XCoords;
	public int YCoords;
	public int XSpacing;
	public int YSpacing;
	public GameObject SlotPrefab;
	public GameObject gridRoot;
	public string LayoutName = "";
	
	 
	
	void Update(){
		
		ClearGrid ();
		CreateGrid ();
		Register ();
		Save();
	}
	
	void Save(){
		if(save){
			save = false;
			PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/" + LayoutName + ".prefab",gridRoot);
		}
	
	}
	
	void ClearGrid(){
		if(clearGrid){
			clearGrid = false;
			for(int i=0;i<slots.Count;i++){
				DestroyImmediate(slots[i]);
			}
			slots.Clear();
		}
	}
	
	void CreateGrid(){
		if(createGrid){
			createGrid = false;
			int index = 0; 
			for(int y=0;y<YCoords;y++){
				for(int x=0;x<XCoords;x++){
					GameObject go = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity) as GameObject;
					go.name = "Slots" + index.ToString(); 
					switch(orientation){
					case Orientation.TopLeft:
						go.transform.position = new Vector3(StartingPosition.x + x*XSpacing, StartingPosition.y, StartingPosition.z - y*YSpacing);
						break;
					}
					go.transform.parent = gridRoot.transform;
					index++;
					slots.Add(go) ;
				}
			}
		}
	}
	
	void Register(){
		
		if(register){
			register = false;
			SceneView.onSceneGUIDelegate -= OnClickToRemove;
			SceneView.onSceneGUIDelegate += OnClickToRemove;
			
		}
	
	}
	
	void OnClickToRemove(SceneView sceneview){
		
		Event e = Event.current;
		if(e.isMouse && e.button ==0 && e.type == EventType.MouseDown){
		  
			Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
			RaycastHit hit;
			if (Physics.Raycast(r, out hit)){
				slots.Remove (hit.collider.gameObject);
				DestroyImmediate(hit.collider.gameObject);
			}
			e.Use();
			
		}
		 
	}
	
	
	
}
