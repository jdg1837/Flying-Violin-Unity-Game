using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ghost : MonoBehaviour {

	public Vector3 position;
	GameObject k;
	bool k_moving; 
	Vector3 k_pos;
	public bool can_move = false;
	public GameObject[] enemies;
	public GameObject[] obstacles;
	public GameObject fire;

	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (can_move == false)
			return;
		
		else {
			k = GameObject.Find ("Player");
			Player knight = k.GetComponent<Player> ();
			k_pos = knight.position;

			position = transform.position;
			compare_distance ();
			move ();
			can_move = false;


		}
	}

	public void move ()
	{
		transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * 100);
		check_for_collisions ();
	}

	void compare_distance()
	{
		Vector3 diff = position - k_pos;
		float xdiff = diff [0];
		float ydiff = diff [1];
		float zdiff;
		float max = Mathf.Abs(ydiff);

		if ((xdiff == 0) || (ydiff == 0))
			zdiff = -1;
		else
			zdiff = Mathf.Sqrt (	((Mathf.Abs (xdiff))*(Mathf.Abs (xdiff)))	+	((Mathf.Abs (ydiff))*(Mathf.Abs (ydiff))));

		if (Mathf.Abs (xdiff) >= max) {
			max = Mathf.Abs (xdiff);
		}

		if (zdiff >= max) {
				max = zdiff;
		}

		if (max == Mathf.Abs(ydiff))
		{
			if (ydiff < 0)
				position += Vector3.up;
			else
				position += Vector3.down;
		} 

		else if (max == Mathf.Abs(xdiff))
		{
			if (xdiff < 0)
				position += Vector3.right;
			else
				position += Vector3.left;
		}

		else
		{
				if (ydiff < 0)
					position += Vector3.up;
				else
					position += Vector3.down;
				if (xdiff < 0)
					position += Vector3.right;
				else
					position += Vector3.left;
		}
	}

	void check_for_collisions()
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");

		foreach (GameObject e in enemies)
		{
			if(e ==  this.gameObject)
				continue;
			
			ghost enemy = e.GetComponent<ghost> ();
			if (enemy == null)
				continue;
			
			if (enemy.position == position) {
				Instantiate (fire, position, Quaternion.identity);
				this.gameObject.SetActive(false);
				enemy.gameObject.SetActive (false);
			}
		}

		obstacles = GameObject.FindGameObjectsWithTag("obstacle");

		foreach (GameObject o in obstacles)
		{

			if (o.transform.position == transform.position) {
				this.gameObject.SetActive(false);
			}
		}
	}
}
