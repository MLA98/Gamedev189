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
        // Default
        if (Input.GetButton("Jump") && FireTimer >= FireRate && GameManager.instance.Ammo > 0)
        {
            var projectile = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f), this.transform.localRotation);
            FireTimer = 0;
            GameManager.instance.Ammo -= 1;
        }
        /*
        // if Spreadshot upgrade is activated
        if (Input.GetButton("Jump") && FireTimer >= FireRate && GameManager.instance.Ammo > 3)
        {
            var projectile1 = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f), this.transform.localRotation);
            var projectile2 = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f) + (this.transform.forward * 0.2f), this.transform.localRotation * Quaternion.Euler(15, 0, 0));
            var projectile3 = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f) - (this.transform.forward * 0.2f), this.transform.localRotation * Quaternion.Euler(-15, 0, 0));
            FireTimer = 0;
            GameManager.instance.Ammo -= 3;
        }
        */
        
    }
}
