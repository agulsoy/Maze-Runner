using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Collider collider;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var character_controller = this.GetComponent<CharacterController>();
        var direction = new Vector3(

            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
            ).normalized;

        var delta = direction * this.speed;
        character_controller.SimpleMove(delta);
    }
}
