using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBuff : MonoBehaviour
{
    [SerializeField]
    private float AmmoAdded;
    private AudioSource PickUpSound;

    private GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;
        PickUpSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            PickUpSound.Play();
            transform.position = new Vector3(transform.position.x,
                            transform.position.y,
                            transform.position.z * 99999f);
            Destroy(this.gameObject, 2.355f);
            instance.Ammo += AmmoAdded;
        }
    }
}
