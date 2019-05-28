using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private static Object ProjectilePrefab;
    private static float SpeedFactor = 5.0f;
    private float FireRate = 0.33f;
    private float FireTimer;

    // Start is called before the first frame update
    void Awake()
    {
        ProjectilePrefab = Resources.Load("Prefabs/Projectile");
    }

    // Update is called once per frame
    void Update()
    {
        FireTimer += Time.deltaTime;
        if (Input.GetButton("Jump") && FireTimer >= FireRate)
        {
            var projectile = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f) , this.transform.localRotation);
            FireTimer = 0;
        }
    }
}
