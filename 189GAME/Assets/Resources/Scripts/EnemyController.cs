using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform planet;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float enemyHealth;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float scoreAdded;
    [SerializeField]
    private bool zigZag;
    [SerializeField]
    private AudioSource collapsedSound;

    private GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;
        planet = GameObject.FindGameObjectWithTag("Planet").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.currState == GameManager.gameState.playing)
        {
            transform.LookAt(planet);
            if (Vector3.Distance(transform.position, planet.position) >= 0)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                if (zigZag)
                {
                    if (transform.position.x <= 1)
                    {
                        transform.position = new Vector3(Mathf.PingPong(Time.time, 1), transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(Mathf.PingPong(Time.time, 1), transform.position.y, transform.position.z);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Mars" || collision.collider.name == "Player")
        {
            collapsedSound.Play();
            transform.position = new Vector3(transform.position.x, 
                            transform.position.y,
                            transform.position.z * 99999f);
            Destroy(this.gameObject, 2.355f);
            instance.Health -= damage;
            instance.hit = true;
            if (instance.Health == 0)
            {
                planet.GetComponent<AudioSource>().Play();
                var em = planet.GetComponent<ParticleSystem>().emission;
                em.enabled = true;
                planet.GetComponent<ParticleSystem>().Play();
                Destroy(planet.gameObject, 1.0f);
                Destroy(GameObject.FindGameObjectWithTag("Player").gameObject, 1.0f);
                instance.currState = GameManager.gameState.gameOver;
            }
        }
        if (collision.collider.tag == "Laser")
        {
            enemyHealth--;
            Destroy(collision.collider.gameObject);
            this.GetComponent<Rigidbody>().AddForce(-transform.forward * 5);
            if (enemyHealth == 0)
            {
                collapsedSound.Play();
                transform.position = new Vector3(transform.position.x,
                                transform.position.y,
                                transform.position.z * 99999f);
                Destroy(this.gameObject, 2.355f);
                instance.Score += scoreAdded;
            }
        }
    }    
}
