using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private static Object ExplosionPrefab;
    public float DestroyTimer;

    private GameManager instance;

    private void Awake()
    {
        instance = GameManager.Instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        ExplosionPrefab = Resources.Load("Prefabs/Explosion");
        DestroyTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyTimer >= 4f)
        {
            Destroy(this.gameObject);
        }
        if (instance.currState != GameManager.gameState.pause)
        {
            DestroyTimer += Time.deltaTime;
            transform.position += transform.up * instance.SpeedFactor * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (instance.AOE && collision.collider.tag == "Enemy")
        {
            var explosion = (GameObject)Instantiate(ExplosionPrefab, this.transform.localPosition, this.transform.localRotation);
        }
    }
}
