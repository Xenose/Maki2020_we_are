using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    float _mouseLastX = 0;
    float _mouseLastY = 0;

    double _lastMouseTime = 50;
    double _currentMouseInterva = 0;

    bool _fireMode = false;

    Camera _cam;

    [SerializeField]
    Vector3 cameraPosition;
    [SerializeField]
    GameObject _bulletPref;
    [SerializeField]
    GameObject _fireIndecator;
    [SerializeField]
    uint _fireIndecatorCount = 3;
    [SerializeField]
    uint _fireIndecatorRadius = 0;

    Vector2 _fireDir = Vector2.zero;
    List<GameObject> _fireIndecators = new List<GameObject>();
    GameObject _arrowFireIndecator;

    private void Awake() 
    {
        base.Awake();
        _cam = Camera.main;

        float angle = 360 / (_fireIndecatorCount - 1);

        _arrowFireIndecator =  Instantiate(_fireIndecator, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        _arrowFireIndecator.transform.SetParent(gameObject.transform);

        for (int i = 0; i < _fireIndecatorCount; i++)
        {
            float posX = Mathf.Cos(angle * i) * _fireIndecatorRadius;
            float posY = Mathf.Sin(angle * i) * _fireIndecatorRadius;

            GameObject current;
            _fireIndecators.Add(current =  Instantiate(_fireIndecator, new Vector3(posX, posY,0), Quaternion.identity) as GameObject);
            current.transform.SetParent(gameObject.transform);
        }
    }

    float arrowAngle = 0;

    private void FixedUpdate() 
    {
        float posX = Mathf.Cos(arrowAngle) * _fireIndecatorRadius;
        float posY = Mathf.Sin(arrowAngle) * _fireIndecatorRadius;
        _arrowFireIndecator.transform.position = new Vector3(gameObject.transform.position.x + posX, gameObject.transform.position.y + posY, 0);

        if (arrowAngle > 360)
        {
            arrowAngle = 0;
        }
        else
        {
            arrowAngle += 0.01f;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _mouseLastY = Mathf.Abs(Input.mousePosition.y);
            _mouseLastX = Input.mousePosition.x;
            _mouseLastY = Input.mousePosition.y;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _currentMouseInterva = Time.fixedTime - _lastMouseTime;
            _lastMouseTime = Time.fixedTime;

            
            if ((int)(Mathf.Abs(Input.mousePosition.y) / 2) != (int)(_mouseLastY / 2))
            {
                float length = Input.mousePosition.y + Input.mousePosition.x;
                Jump(new Vector2(
                    ((-(Input.mousePosition.x - _mouseLastX)) / length), 
                    (-(Input.mousePosition.y - _mouseLastY)) / length));
            }
            else if (_fireMode)
            {  
                _fireMode = false;

                GameObject _bullet = Instantiate(_bulletPref);
                Bullet tmp = _bullet.AddComponent<Bullet>();

                tmp.Fire(
                    gameObject.transform.position, 
                    new Vector2(
                        _fireDir.x, 
                        _fireDir.y - Screen.height / 2 - cameraPosition.y), 
                        4.0f);

                _body.constraints = 
                    RigidbodyConstraints2D.None | 
                    RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                _fireMode = true;
                _fireDir = Input.mousePosition;

                _body.constraints = 
                    RigidbodyConstraints2D.FreezePositionX |
                    RigidbodyConstraints2D.FreezePositionY |
                    RigidbodyConstraints2D.FreezeRotation;
            }
        }

        /*if (Input.GetButton("Fire1"))
        {   
            Debug.Log(_currentMouseInterva);
            
            if (Mathf.Abs(_body.velocity.y) <= 0.1 && _currentMouseInterva > 0.3)
            {   
                if ((int)(Mathf.Abs(Input.mousePosition.y) / 20) == (int)(_mouseLastY / 20))
                {
                    if (Input.mousePosition.x > Screen.width / 2
                    )
                        Move(1.0f);
                    else
                        Move(-1.0f);
                }
            }
        }*/
    }

    void LateUpdate()
    {
        _cam.transform.position = new Vector3(
            gameObject.transform.position.x + cameraPosition.x, 
            gameObject.transform.position.y + cameraPosition.y, 
            cameraPosition.z);
    }
}
