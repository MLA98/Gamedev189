using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float DestroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        DestroyTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTimer += Time.deltaTime;
        if (DestroyTimer >= 4f)
        {
            Destroy(this.gameObject);
        }
        transform.position += transform.up * Time.deltaTime;
    }
}
