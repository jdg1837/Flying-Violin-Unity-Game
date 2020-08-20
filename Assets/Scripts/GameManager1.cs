using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour {

	public static int PlayerScore1 = 0;
	public static int AIScore = 0;
	public GUISkin layout;
	GameObject theBall;

	void Start () {
		theBall = GameObject.FindGameObjectWithTag("Ball");
	}
	
	public static void Score (string wallID) {
		if (wallID == "RightWall")
		{
			PlayerScore1++;
		} else
		{
			AIScore++;
		}
	}

	void OnGUI () {
		GUI.skin = layout;
        GUI.skin.label.fontSize = 100;
		GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 200, 200), "" + PlayerScore1);
		GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 200, 200), "" + AIScore);

		if (PlayerScore1 == 5)
		{
			GUI.Label(new Rect(Screen.width / 2 - 300, 200, 2000, 1000), "YOU WIN");
			theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
			Save.Instance.lost = 0;
			Save.Instance.score = Save.Instance.score + 100;
			SceneManager.LoadScene (6);
		} else if (AIScore == 5)
		{
			GUI.Label(new Rect(Screen.width / 2 - 300, 200, 2000, 1000), "YOU LOSE");
			theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);

			Save.Instance.lost = 1;
			SceneManager.LoadScene (6);
		}
	}
}
