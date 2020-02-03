using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] 
    string _nextSceneIndex;

    void OnTriggerEnter2D(Collider2D col)
    {
        if ("Player" == col.gameObject.tag)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
