﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform planet;
    private float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(planet);
        if (Vector3.Distance(transform.position, planet.position) >= 0)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Mars" || collision.collider.name == "Player")
        {
            Destroy(this.gameObject);
            GameManager.instance.Health -= 1;
            if (GameManager.instance.Health == 0)
            {
                Destroy(planet.gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
            }
        }
        if (collision.collider.tag == "Laser")
        {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
            GameManager.instance.Score += 1;
        }
    }
    
}
