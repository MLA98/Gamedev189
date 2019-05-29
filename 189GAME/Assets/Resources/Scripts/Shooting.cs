using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private static Object ProjectilePrefab;
    private static float SpeedFactor = 5.0f;
    private float FireTimer;
    [SerializeField]
    private AudioSource ShootSound;

    // Start is called before the first frame update
    void Start()
    {
        ProjectilePrefab = Resources.Load("Prefabs/Projectile");
    }

    // Update is called once per frame
    void Update()
    { 
        FireTimer += Time.deltaTime;
        // Default
        if (Input.GetButton("Jump") && FireTimer >= GameManager.instance.PlayerFireRate && GameManager.instance.Ammo > 0 && !GameManager.instance.spread)
        {
            var projectile = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f), this.transform.localRotation);
            FireTimer = 0;
            GameManager.instance.Ammo -= 1;
            ShootSound.Play();
        }
        if (Input.GetButton("Jump") && FireTimer >= GameManager.instance.PlayerFireRate && GameManager.instance.Ammo > 3 && GameManager.instance.spread)
        {
            var projectile1 = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f), this.transform.localRotation);
            var projectile2 = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f) + (this.transform.forward * 0.2f), this.transform.localRotation * Quaternion.Euler(15, 0, 0));
            var projectile3 = (GameObject)Instantiate(ProjectilePrefab, this.transform.localPosition + (this.transform.up * 0.2f) - (this.transform.forward * 0.2f), this.transform.localRotation * Quaternion.Euler(-15, 0, 0));
            FireTimer = 0;
            GameManager.instance.Ammo -= 3;
        }
    }
}
