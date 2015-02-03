using UnityEngine;
using System.Collections;

public class CoisasCaindo : MonoBehaviour {

	public GameObject hazard; // coisa que vai cair
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject M;
	
	void Start(){
		StartCoroutine (SpawnWaves ());
	}
	
	
	
	IEnumerator SpawnWaves(){
		
		yield return new WaitForSeconds (startWait); 
		while(true){
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject mm = Instantiate (hazard, spawnPosition, spawnRotation) as GameObject;
				mm.transform.parent = M.transform;
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
	
	
	
	
	
}
