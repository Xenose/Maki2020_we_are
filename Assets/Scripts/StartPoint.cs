using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
	[SerializeField] 
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(player, this.transform.position, Quaternion.identity);
    }
}
