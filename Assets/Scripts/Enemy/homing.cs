using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class homing : MonoBehaviour {
	// The target marker.

	// Speed in units per sec.
	public float speed;
	
	GameObject _player;

	private void Start() {
		_player = GameObject.FindWithTag("Player");	
	}

	void FixedUpdate( ) {
		// The step size is equal to speed times frame time.
		float step = speed * Time.deltaTime;

		// Move our position a step closer to the target.
		if (_player)
			transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, step);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			collision.gameObject.GetComponent<Entity>().Damage(100);
		}
	}
}