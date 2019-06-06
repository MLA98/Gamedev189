using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    private GameObject Mars;
    [SerializeField]
    private float Speed;
    private AudioSource PickUpSound;

    private GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;
        PickUpSound = GetComponent<AudioSource>();
        Mars = GameObject.FindGameObjectWithTag("Planet");
        this.transform.LookAt(Mars.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.currState == GameManager.gameState.playing)
        {
                transform.position += transform.forward * Speed * Time.deltaTime;
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
            // Set health to max instead of adding over max
            instance.Health = 10;
        }
    }
}
