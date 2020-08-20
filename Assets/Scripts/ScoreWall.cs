using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWall : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball")
		{
			string wallName = transform.name;
			GameManager1.Score(wallName);
			hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
		}
	}
}