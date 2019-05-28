using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 20;
    private Vector3 moveDir;
    private Vector3 MovementDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(0, 0, -Input.GetAxisRaw("Horizontal"));
    }

    private void FixedUpdate()
    {
        transform.GetComponent<Rigidbody>().MovePosition(transform.GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir) * moveSpeed * Time.fixedDeltaTime);
    }
}
