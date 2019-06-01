using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private static Object ExplosionPrefab;
    public float DestroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        ExplosionPrefab = Resources.Load("Prefabs/Explosion");
        DestroyTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currState == GameManager.gameState.playing)
        {
            DestroyTimer += Time.deltaTime;
        }
        if (DestroyTimer >= 4f)
        {
            Destroy(this.gameObject);
        }
        if (GameManager.instance.currState == GameManager.gameState.playing)
        {
            transform.position += transform.up * GameManager.instance.SpeedFactor * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.AOE && collision.collider.tag == "Enemy")
        {
            var explosion = (GameObject)Instantiate(ExplosionPrefab, this.transform.localPosition, this.transform.localRotation);
        }
    }
}
