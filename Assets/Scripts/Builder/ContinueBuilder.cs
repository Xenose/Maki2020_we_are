using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueBuilder : MonoBehaviour
{
    public void PushStartButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
