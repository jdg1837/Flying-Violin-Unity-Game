using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject k;
	public Player knight; 

	// Use this for initialization
	public void Start () {
	}

	public void OnStay (){
		k = GameObject.Find ("Player");
		Player knight = k.GetComponent<Player> ();

		if (knight.can_move == false)
			return;

		knight.move (0);
	}

	public void OnTP (){
		k = GameObject.Find ("Player");
		Player knight = k.GetComponent<Player> ();

		if (knight.can_move == false)
			return;

		knight.move (1);
	}

	public void OnUp (){
		k = GameObject.Find ("Player");
		Player knight = k.GetComponent<Player> ();

		if (knight.can_move == false)
			return;

		knight.move (2);
	}

	public void OnDown (){
		k = GameObject.Find ("Player");
		Player knight = k.GetComponent<Player> ();

		if (knight.can_move == false)
			return;

		knight.move (3);
	}

	public void OnLeft (){
		k = GameObject.Find ("Player");
		Player knight = k.GetComponent<Player> ();

		if (knight.can_move == false)
			return;

		knight.move (4);
	}

	public void OnRight (){
		k = GameObject.Find ("Player");
		Player knight = k.GetComponent<Player> ();

		if (knight.can_move == false)
			return;

		knight.move (5);
	}
}
