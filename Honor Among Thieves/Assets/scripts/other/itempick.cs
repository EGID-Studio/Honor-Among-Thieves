using UnityEngine;
using System.Collections;

public class itempick : MonoBehaviour {
	public int itemid;
	public ArrayList info;
	public int count;
	// Use this for initialization
	void Start () {
		info = new ArrayList ();
		info.Add (itemid);
		info.Add (this.gameObject);
		info.Add (count);
	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D(Collision2D col){
		col.gameObject.SendMessage ("AddItem",info);
	}
	void OnTriggerEnter2D(Collider2D col){
		col.gameObject.SendMessage ("AddItem",info);
	}
	public void dest(bool des){
		if (des) {
			Destroy (this.gameObject);
		}
	}
}
