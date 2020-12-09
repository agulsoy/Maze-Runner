using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
	public Transform player;
	public Vector3 direction;
	// private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	direction.x = player.position.x;
    	direction.y = this.transform.position.y;
    	direction.z = this.transform.position.z;
    	this.transform.position = direction;
    }
}
