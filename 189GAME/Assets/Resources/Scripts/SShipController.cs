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
    private float ScoreAdded;
    [SerializeField]
    private GameObject AmmoBuff;
    [SerializeField]
    private GameObject HealthBuff;
    private AudioSource CollapsedSound;

    private GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;
        CollapsedSound = GetComponent<AudioSource>();
        // Move from one side of the screen to the other
        if (Random.value > 0.5)
        {
            Target = new Vector3(-this.transform.localPosition.x, 0, this.transform.localPosition.z);
        }
        else
        {
            Target = new Vector3(this.transform.localPosition.x, 0, -this.transform.localPosition.z);
        }
        this.transform.LookAt(Target);
    }

    // Update is called once per frame
    void Update()
    {
        if(instance.currState == GameManager.gameState.playing)
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
        if (collision.collider.tag == "Laser")
        {
            // If health is needed
            if (instance.Health <= 9)
            {
                int dice = Random.Range((int)0, (int)2);
                switch (dice)
                {
                    case 0:
                        Instantiate(AmmoBuff, this.transform.position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(HealthBuff, this.transform.position, Quaternion.identity);
                        break;
                }
            }
            // Else just give ammo
            else
            {
                Instantiate(AmmoBuff, this.transform.position, Quaternion.identity);
            }
        }
        Destroy(collision.collider.gameObject);
        CollapsedSound.Play();
        transform.position = new Vector3(transform.position.x,
        transform.position.y,
        transform.position.z * 99999f);
        Destroy(this.gameObject, 2.355f);
        instance.Score += ScoreAdded;
    }
}
