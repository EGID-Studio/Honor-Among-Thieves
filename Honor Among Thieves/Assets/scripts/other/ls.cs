using UnityEngine;
using System.Collections;
using System;

public class ls : MonoBehaviour {
	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().sortingOrder = Convert.ToInt32(this.transform.position.y * -10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
