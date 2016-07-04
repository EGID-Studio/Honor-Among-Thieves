using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class eq : MonoBehaviour {
	public ArrayList eqs;
	public int eqlenght;
	// Use this for initialization
	void Start () {
		eqs = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void AddItem(ArrayList id){
		if ((eqs.Count/2) < eqlenght) {
			GameObject tmp = id [1] as GameObject;
			tmp.SendMessage ("dest", true);
			if (eqs.Contains (id [0])) {
				eqs.Insert(eqs.IndexOf (id [0])+1,Convert.ToInt32(eqs[eqs.IndexOf (id [0])+1]) + Convert.ToInt32(id[2]));

			} else {
				eqs.Add (id [0]);
				eqs.Add (id [2]);
			}
		}

		Debug.Log (id[0]);
	}
}
