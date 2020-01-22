using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBuilder : MonoBehaviour
{
    public void PushStartButton()
    {
        SceneManager.LoadScene("title");
    }
}
