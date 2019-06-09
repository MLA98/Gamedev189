using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    GameObject HUDGameObject;
    GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;   
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.currState == GameManager.gameState.playing)
        {
            HUDGameObject.SetActive(true);
        } else
        {
            HUDGameObject.SetActive(false);
        }
    }
}
