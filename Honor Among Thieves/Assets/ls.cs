using UnityEngine;
using System.Collections;

public class ls : MonoBehaviour {
	public GameObject pazdan;
	// Use this for initialization
	void Start () {
		pazdan = GameObject.Find ("PAZDAN");
	}
	
	// Update is called once per frame
	void Update () {
		if (pazdan.transform.position.y < this.transform.position.y - 0.1) {
			this.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		} else {
			this.GetComponent<SpriteRenderer> ().sortingOrder = 3;
		}
	}
}
