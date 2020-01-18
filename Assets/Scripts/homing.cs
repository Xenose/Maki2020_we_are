using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class homing : MonoBehaviour {
	// The target marker.

	// Speed in units per sec.
	public float speed;

	void FixedUpdate( ) {
		// The step size is equal to speed times frame time.
		float step = speed * Time.deltaTime;

		// Move our position a step closer to the target.
		transform.position = Vector3.MoveTowards( transform.position, GameObject.FindWithTag("Player").transform.position, step );
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(collision.gameObject.tag);
		if (collision.gameObject.tag == "Player") 
			{
				collision.gameObject.GetComponent<Entity>().Damage(100);
			}
	}
}