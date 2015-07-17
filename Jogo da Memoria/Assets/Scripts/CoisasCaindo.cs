using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoisasCaindo : MonoBehaviour {

	public GameObject hazard; // coisa que vai cair
	public GameObject hazard2;
	public GameObject hazard3;
	public GameObject M;
	
	public List<GameObject> m3 = new List<GameObject>();
	
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	void Start(){
		StartCoroutine (SpawnWaves ());
	}
	
	
	IEnumerator SpawnWaves(){
		
		yield return new WaitForSeconds (startWait); 
		while(true){
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				int r1 = Random.Range(0, m3.Count);
				GameObject mm = Instantiate (m3[r1], spawnPosition, spawnRotation) as GameObject;
				mm.transform.parent = M.transform;
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
	
	
	
	
	
}
