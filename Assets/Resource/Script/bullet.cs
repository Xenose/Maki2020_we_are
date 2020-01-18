using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    [SerializeField] float Speed;

    Vector3 dir = Vector3.zero;

    // Start is called before the first frame update
    void Start( ) 
    {
        //dir = transform.rotation * Vector3.up * Speed;
        //Rigidbody2D body = GetComponent<Rigidbody2D>();
        //body.velocity = dir;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

