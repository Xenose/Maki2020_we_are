using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected enum State
    {
        IDLE,
        WALKING,
        JUMPING,
        ATTACKING
    };

    protected enum ColliderType
    {
        CIRCLE,
        BOX
    };
    
    protected Rigidbody2D _body;
    protected Animator _anime = null;

    [SerializeField]
    protected State _state = State.IDLE;
    [SerializeField]
    protected uint _hp = 100;
    [SerializeField]
    protected float _speed = 5.0f;
    [SerializeField]
    protected float _speedLimit = 5.0f;
    [SerializeField]
    protected ColliderType _colliderType = ColliderType.BOX;

    public virtual void Awake() 
    {
        _body = gameObject.AddComponent<Rigidbody2D>();

        switch(_colliderType)
        {
            case ColliderType.CIRCLE:
                gameObject.AddComponent<CircleCollider2D>();
                break;
            case ColliderType.BOX:
                gameObject.AddComponent<BoxCollider2D>();
                break;
        }
        
        _body.constraints = 
            RigidbodyConstraints2D.None |
            RigidbodyConstraints2D.FreezeRotation;

        try 
        {
            _anime = gameObject.GetComponent<Animator>();
        }
        catch
        {

        }
    }

    public virtual void Move(float speedIn)
    {
        _body.velocity = new Vector2(speedIn * _speed, _body.velocity.y);
    }
    public virtual void Jump(Vector2 forec)
    {
        _body.AddForce(forec * 1200);
    }

    public virtual void Damage(uint value)
    {
        _hp -= value;

        if (0 >= _hp)
        {
            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        if (Mathf.Abs(_body.velocity.y) > 0.1f)
        {
            _state = State.JUMPING;
        }
        else if (Mathf.Abs(_body.velocity.x) > 0.1f)
        {
            _state = State.WALKING;

            if (null != _anime)
            {
                _anime.SetBool("Running", true);
            }
        }
        else
        {
            _state = State.IDLE;
            
            if (null != _anime)
            {
                _anime.SetBool("Running", false);
            }
        }

        if (_body.velocity.x < 0.1)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (Mathf.Abs(_body.velocity.x) < 0.1)
        {
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
}
