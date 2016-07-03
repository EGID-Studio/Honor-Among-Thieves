using UnityEngine;
using System.Collections;

public class mvc : MonoBehaviour {
	public Animator par;
	public Rigidbody2D r2d;
	public int sm;
	void Awake(){
		par = this.GetComponent<Animator>();
		r2d = this.GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	void FixedUpdate(){

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("SM")) {
			if (sm == 1) {
				sm = sm*2;
			} else {
				sm = sm/2;
			}
		}
		if (Input.GetAxisRaw ("Vertical") > 0.1F) {
			r2d.velocity = new Vector2 (r2d.velocity.x, Input.GetAxisRaw ("Vertical")*sm);
			par.speed = Input.GetAxisRaw ("Vertical") * sm;
			par.SetInteger ("wv", 1);
		} else if (Input.GetAxisRaw ("Vertical") < -0.1F) {
			r2d.velocity = new Vector2 (r2d.velocity.x, Input.GetAxisRaw ("Vertical")*sm);
			par.speed = Input.GetAxisRaw ("Vertical") * sm *-1;
			par.SetInteger ("wv", -1);
		} else {
			r2d.velocity = new Vector2 (r2d.velocity.x, 0);
			par.SetInteger ("wv", 0);
		}
		if(Input.GetAxisRaw("Horizontal") > 0.1F){
			r2d.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")*sm, r2d.velocity.y);
			par.speed = Input.GetAxisRaw ("Horizontal") * sm;
			par.SetInteger ("wh", 1);
		}else if(Input.GetAxisRaw("Horizontal") < -0.1F){
			r2d.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")*sm, r2d.velocity.y);
			par.speed = Input.GetAxisRaw ("Horizontal") * sm *-1;
			par.SetInteger ("wh", -1);
		} else {
			r2d.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")*sm, r2d.velocity.y);
			par.SetInteger ("wh", 0);
		}
	}
}
