using UnityEngine;
using System.Collections;

public class grid : MonoBehaviour {
	public int x;
	public int y;
	public GameObject go;
	public GameObject gox;
	public GameObject goxx;
	public GameObject tmpg;
	//0.96
	// Use this for initialization
	void Start () {
		for (int i = 0; i < x; i++) {
			for (int n = 0; n < y; n++) {
				Instantiate (go, new Vector3 (this.transform.position.x + (0.96F * i),this.transform.position.y + (0.96F * n),1), this.transform.rotation);
				if (Random.Range (0, 100) < 2 || Random.Range (0, 100) > 98) {
					tmpg = Instantiate (gox, new Vector3 (this.transform.position.x + (0.96F * i),this.transform.position.y + (0.96F * n),1), this.transform.rotation) as GameObject;
					tmpg.GetComponent<SpriteRenderer> ().sortingOrder = 1;
				}else if (Random.Range (0, 100) < 88  && Random.Range (0, 100) > 84) {
					tmpg = Instantiate (goxx, new Vector3 (this.transform.position.x + (0.96F * i),this.transform.position.y + (0.96F * n),1), this.transform.rotation) as GameObject;
					tmpg.GetComponent<SpriteRenderer> ().sortingOrder = 1;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
