using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GerarCartas : MonoBehaviour
{

		public Vector3 PosicaoInicial = new Vector3 ();
		public int espacamentoX = 3;
		public int espacamentoY = 4;
		public int cartasx = 2;
		public int cartasy = 3;
		public GameObject parent;

		void Start ()
		{
			EmbaralharCartas ();
		}

		public List<GameObject> cartas = new List<GameObject> ();
		public void EmbaralharCartas ()
		{
				int ncartas = cartas.Count;
				List<GameObject> temp = new List<GameObject> ();
				for (int i =0; i<ncartas; i++) {
						int random = Random.Range (0, ncartas - i);
						temp.Add (cartas [random]);
						cartas.RemoveAt (random);
				}
				cartas = temp;
				Gerar ();
		}
		
		void Gerar ()
		{
			int i = 0;
			for (int y=0; y<cartasy; y++) {
				for (int x=0; x<cartasx && i<cartas.Count; x++) {
					GameObject c = Instantiate (cartas [i], Vector2.zero, Quaternion.identity) as GameObject;
					c.transform.position = new Vector3 (PosicaoInicial.x + x * espacamentoX, PosicaoInicial.y - y * espacamentoY);
					c.transform.parent = parent.transform;
					i++;
				}
			}
		}

}
