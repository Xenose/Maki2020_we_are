using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Up: MonoBehaviour
{
    [SerializeField]
    public float speed;

    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Entity>().Damage(100);
            Destroy(this.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }
}
