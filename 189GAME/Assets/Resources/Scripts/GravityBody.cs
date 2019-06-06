﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private GravityAttractor attractor;

    private void Awake()
    {
        attractor = GameObject.Find("Mars").GetComponent<GravityAttractor>();
    }

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
