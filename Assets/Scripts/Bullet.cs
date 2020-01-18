using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _body;
    BoxCollider2D _coll;

    public void Fire(Vector2 start, Vector2 target, float speed = 1.0f)
    {
        gameObject.transform.position = start;
        _body.AddForce(new Vector2(
            (target.x - Screen.width / 2 ) * speed, 
            target.y * speed));
    }

    private void Awake() 
    {
        _body = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        _body.gravityScale = 0;
        _coll = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        _coll.isTrigger = true;

        Destroy(gameObject, 5);
    }
}
