using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControls : MonoBehaviour {

	public float speed = 100f;
	public float boundY = 2.25f;
    public float directionY;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

    // Update is called once per frame
    void Update()
    {
        directionY = CrossPlatformInputManager.GetAxis("Vertical");
        rb2d.velocity = new Vector2(0, directionY * speed);
        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
