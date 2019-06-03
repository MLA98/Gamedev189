using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    private GameObject Mars;
    [SerializeField]
    private float HealthAdded;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private AudioSource PickUpSound;
    // Start is called before the first frame update
    void Start()
    {
        Mars = GameObject.FindGameObjectWithTag("Planet");
        this.transform.LookAt(Mars.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currState == GameManager.gameState.playing)
        {
            if (Vector3.Distance(transform.position, Mars.transform.position) >= 0)
            {
                transform.position += transform.forward * Speed * Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Mars" || collision.collider.name == "Player")
        {
            PickUpSound.Play();
            transform.position = new Vector3(transform.position.x,
                            transform.position.y,
                            transform.position.z * 99999f);
            Destroy(this.gameObject, 2.355f);
            GameManager.instance.Health += HealthAdded;
        }
    }
}
