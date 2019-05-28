using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        transform.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(transform);
    }
}
