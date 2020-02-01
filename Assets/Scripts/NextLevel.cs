using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    Scene _nextScene;
    List<GameObject> _enemyies = new List<GameObject>();

    void Start()
    {
        _enemyies.Add(GameObject.FindGameObjectWithTag("enemy"));
        Debug.Log("gameobjects " + _enemyies.Count);
    }

    void LateUpdate()
    {
        for (int i = 0; i < _enemyies.Count; i++)
        {
            if (!_enemyies[i].gameObject)
            {
                Debug.Log("removing enemy at " + i.ToString());
                _enemyies.RemoveAt(i);
                return;
            }
        }

        if (_enemyies.Count <= 0)
        {
            Debug.Log("you win!");
        }
    }
}
