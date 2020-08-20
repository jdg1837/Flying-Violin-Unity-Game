using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAI : MonoBehaviour {

	public float speed = 8;
	public float lerpSpeed = 1f;
	private Rigidbody2D rigidBody;
	public float boundY = 2.25f;

	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		GameObject b = GameObject.Find("Ball");
		BallControl bc = b.GetComponent<BallControl> ();
		Rigidbody2D ball = bc.rb2d;
		if (ball.velocity.x > 0) 
		{
			if (GameObject.FindGameObjectWithTag("Ball").transform.position.y > transform.position.y)
			{
                if (rigidBody.velocity.y < 0)
                {
                    rigidBody.velocity = Vector2.zero;
                }
				rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.up * speed, lerpSpeed * Time.deltaTime);
			}
			else if (GameObject.FindGameObjectWithTag("Ball").transform.position.y < transform.position.y)
			{
                if (rigidBody.velocity.y > 0)
                {
                    rigidBody.velocity = Vector2.zero;
                }
				rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.down * speed, lerpSpeed * Time.deltaTime);
			}
			else
			{
				rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero * speed, lerpSpeed * Time.deltaTime);
			}
		}

		var pos = transform.position;
		if (pos.y > boundY) {
			pos.y = boundY;
		} else if (pos.y < -boundY) {
			pos.y = -boundY;
		}
		transform.position = pos;

	}
}
