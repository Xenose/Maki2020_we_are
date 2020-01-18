using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{

	[SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
