using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Shot(){

        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(bullet, transform);
        }
    }

}
