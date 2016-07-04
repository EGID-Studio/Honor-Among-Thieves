using UnityEngine;
using System.Collections;
using Pathfinding;
using System;

public class test : MonoBehaviour {
	//The point to move to
	public Animator par;
	public Vector2 lastpos;
	public Transform target;

	private Seeker seeker;

	//The calculated path
	public Path path;

	//The AI's speed per second
	public float speed = 2;

	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;

	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	void Awake(){
		par = this.GetComponent<Animator>();
	}
	public void Start ()
	{
		par.speed = speed/2;
		lastpos = this.transform.position;
		seeker = GetComponent<Seeker>();

		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		seeker.StartPath( transform.position, target.position, OnPathComplete );
	}

	public void OnPathComplete ( Path p )
	{
		Debug.Log( "Yay, we got a path back. Did it have an error? " + p.error );
		if (!p.error)
		{
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}

	public void Update ()
	{
		this.GetComponent<SpriteRenderer>().sortingOrder = Convert.ToInt32(this.transform.position.y * -10);
		if (this.transform.position.x > lastpos.x) {
			par.SetInteger ("wh", 1);
		} else if (this.transform.position.x < lastpos.x) {
			par.SetInteger ("wh", -1);
		} else if (this.transform.position.y > lastpos.y) {
			par.SetInteger ("wv", 1);
		} else if (this.transform.position.y < lastpos.y) {
			par.SetInteger ("wv", -1);
		} else {
			par.SetInteger ("wv", 0);
			par.SetInteger ("wh", 0);
		}
		lastpos = this.transform.position;
		if (path == null)
		{
			//We have no path to move after yet
			return;
		}

		if (currentWaypoint >= path.vectorPath.Count)
		{
			return;
		}

		//Direction to the next waypoint
		Vector3 dir = ( path.vectorPath[ currentWaypoint ] - transform.position ).normalized;
		dir *= speed * Time.fixedDeltaTime;
		this.gameObject.transform.Translate( dir );
		if (this.transform.position.x > lastpos.x) {
			par.SetInteger ("wh", 1);
		} else if (this.transform.position.x < lastpos.x) {
			par.SetInteger ("wh", -1);
		} else if (this.transform.position.y > lastpos.y) {
			par.SetInteger ("wv", 1);
		} else if (this.transform.position.y < lastpos.y) {
			par.SetInteger ("wv", -1);
		} else {
			par.SetInteger ("wv", 0);
			par.SetInteger ("wh", 0);
		}
		lastpos = this.transform.position;
		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance( transform.position, path.vectorPath[ currentWaypoint ] ) < nextWaypointDistance)
		{
			currentWaypoint++;
			return;
		}
	}
}
