using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SShipController : MonoBehaviour
{
    private Vector3 Target;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Health;

    // Start is called before the first frame update
    void Start()
    {
        Target = new Vector3(Random.Range(-5, 4), 0, Random.Range(-6, 5));
        Debug.Log(Target);
        this.transform.LookAt(Target);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currState == GameManager.gameState.playing)
        {
            this.transform.position += transform.forward * Speed * Time.deltaTime;
        }

    }
}
