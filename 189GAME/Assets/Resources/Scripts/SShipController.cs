using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SShipController : MonoBehaviour
{
    private Vector3 Target;
    private float Timer = 0;
    [SerializeField]
    private float LifeSpan;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Health;
    [SerializeField]
    private float ScoreAdded;
    [SerializeField]
    private GameObject AmmoBuff;
    [SerializeField]
    private GameObject HealthBuff;
    [SerializeField]
    private float Damage;
    [SerializeField]
    private AudioSource CollapsedSound;
    // Start is called before the first frame update
    void Start()
    {
        Target = new Vector3(Random.Range(-3, 2), 0, Random.Range(-5, 4));
        Debug.Log(Target);
        this.transform.LookAt(Target);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currState == GameManager.gameState.playing)
        {
            Timer += Time.deltaTime;
            if(Timer >= LifeSpan)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.transform.position += transform.forward * Speed * Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Mars" || collision.collider.name == "Player")
        {
            CollapsedSound.Play();
            transform.position = new Vector3(transform.position.x,
                            transform.position.y,
                            transform.position.z * 99999f);
            Destroy(this.gameObject, 2.355f);
            GameManager.instance.Health -= Damage;
            GameManager.instance.hit = true;
            if (GameManager.instance.Health == 0)
            {
                var planet = GameObject.FindGameObjectWithTag("Planet");
                Destroy(planet.gameObject);
                Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
                GameManager.instance.currState = GameManager.gameState.gameOver;
            }
        }
        if (collision.collider.tag == "Laser")
        {
            CollapsedSound.Play();
            Health--;
            Debug.Log("Health is" + Health);
            Destroy(collision.collider.gameObject);
            this.GetComponent<Rigidbody>().AddForce(-transform.forward * 5);
            if (Health <= 0)
            {
                int dice = Random.Range((int)0, (int)2);
                switch (dice)
                {
                    case 0:
                        Instantiate(AmmoBuff, this.transform.position, Quaternion.identity);
                        Debug.Log("Instantiated");
                        break;
                    case 1:
                        Instantiate(HealthBuff, this.transform.position, Quaternion.identity);
                        Debug.Log("Instantiated");
                        break;
                }
                transform.position = new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z * 99999f);
                Destroy(this.gameObject, 2.355f);
                GameManager.instance.Score += ScoreAdded;
            }
        }
    }
}
