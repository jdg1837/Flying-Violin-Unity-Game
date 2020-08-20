using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player: MonoBehaviour
{
	public bool can_move = true;
	public Vector3 position;
	public GameObject[] enemies;
	public GameObject[] obstacles;
	public int teleports_left = 5;
	public int moves = 0;

	void Update()
	{
		check_for_collisions ();
		check_for_ghosts ();
		check_ghosts_movement ();

		if (moves >= 12) {
			Save.Instance.lost = 0;
			Save.Instance.score = Save.Instance.score + 100;
			SceneManager.LoadScene (6);
		}
	}

	public void move(int dir)
	{
		bool moved = false;

		position = transform.position;

		if(dir == 0)
			moved = true;

		else if ((dir == 1) && (teleports_left > 0)) {
			teleport ();
			teleports_left--;
		}

		else if((dir == 2) && (position [1] <= 3))
		{
				position += Vector3.up;
				moved = true;
		}
		else if((dir == 3) && (position [1] >= -3))
		{
			position += Vector3.down;
			moved = true;
		}
		else if((dir == 4) && (position [0] >= -7))
		{
			position += Vector3.left;
			moved = true;
		}
		else if((dir == 5) && (position [0] <= 7 ))
		{
			position += Vector3.right;
			moved = true;
		}

		if (moved) {
			transform.position = Vector3.MoveTowards (transform.position, position, Time.deltaTime * 100);
			moves++;
			can_move = false;
			change_ghosts_movement ();
		}
	}

	void check_for_ghosts ()
	{
		bool all_dead = true;
		enemies = GameObject.FindGameObjectsWithTag("enemy");

		foreach (GameObject enemy in enemies)
		{
			if (enemy.gameObject.activeSelf == true) {
				all_dead = false;
				break;
			}
		}

		if (all_dead) {
			Save.Instance.lost = 0;
			Save.Instance.score = Save.Instance.score + 100;
			SceneManager.LoadScene (6);
		}
	}

	void check_for_collisions ()
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		obstacles = GameObject.FindGameObjectsWithTag("obstacle");

		foreach (GameObject enemy in enemies)
		{
			if (enemy.transform.position == transform.position) {
				Save.Instance.lost = 1;
				SceneManager.LoadScene (6);
			}
		}

		foreach (GameObject obstacle in obstacles)
		{
			if (obstacle.transform.position == transform.position) {
				Save.Instance.lost = 1;
				SceneManager.LoadScene (6);
			}
		}
	}

	void check_ghosts_movement ()
	{
		bool ghosts_moved = true;

		enemies = GameObject.FindGameObjectsWithTag("enemy");

		foreach (GameObject e in enemies)
		{
			ghost enemy = e.GetComponent<ghost> ();
			if (enemy == null)
				continue;
			
			if (enemy.can_move == true) {
				ghosts_moved = false;
			}
		}

		can_move = ghosts_moved;
	}

	void change_ghosts_movement ()
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");

		foreach (GameObject e in enemies)
		{
			ghost enemy = e.GetComponent<ghost> ();
			if (enemy == null)
				continue;
			enemy.can_move = true;
		}
	}

	void teleport ()
	{
		int x, y, offset;
		Vector3 temp = transform.position;
		bool is_valid = true;


		enemies = GameObject.FindGameObjectsWithTag("enemy");
		obstacles = GameObject.FindGameObjectsWithTag("obstacle");

		offset = (int)Mathf.Abs (transform.position [0]);

		while (true) {
				
			x = (int)Random.Range (1 + offset, 8 + offset);

			if (transform.position [0] >= 0) {
				for (int i = 0; i < x; i++)
					temp += Vector3.left;
			}
			else
				for (int i = 0; i < x; i++)
					temp += Vector3.right;

			foreach (GameObject e in enemies)
			{
				ghost enemy = e.GetComponent<ghost> ();
				if (enemy == null)
					continue;
				
				if (enemy.position == temp) {
					is_valid = false;
					break;
				}
			}

			foreach (GameObject o in obstacles)
			{
				if (o.transform.position == temp) {
					is_valid = false;
					break;
				}
			}

			if (is_valid)
				break;
		}

		transform.position = temp;

		offset = (int)Mathf.Abs (transform.position [1]);

		while (true) {

			y = (int)Random.Range (1 + offset, 4 + offset);

			if (transform.position [1] >= 0) {
				for (int i = 0; i < y; i++)
					temp += Vector3.down;
			}
			else
				for (int i = 0; i < y; i++)
					temp += Vector3.up;

			foreach (GameObject e in enemies)
			{
				ghost enemy = e.GetComponent<ghost> ();
				if (enemy == null)
					continue;

				if (enemy.position == temp) {
					is_valid = false;
					break;
				}
			}

			foreach (GameObject o in obstacles)
			{
				if (o.transform.position == temp) {
					is_valid = false;
					break;
				}
			}

			if (is_valid)
				break;
		}

		transform.position = temp;
	}
}
