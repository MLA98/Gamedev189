using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SShipSpawner : MonoBehaviour
{
    public GameObject SShipPrefab;

    private float spawnRate;
    private float timer;
    private float SShipCounter;
    private float waveLimit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        waveLimit = GameManager.instance.Wave * 2;
        spawnRate = 10 + 0.1f * (GameManager.instance.Wave - 1);
        timer += Time.deltaTime;
        if (timer >= spawnRate && GameManager.instance.currState == GameManager.gameState.playing && SShipCounter <= waveLimit)
        {
            Vector3 offset;
            offset.x = Random.value > 0.5f ?
                Random.Range(-8f, -10f) :
                Random.Range(8f, 10f);
            offset.y = 0f;
            offset.z = Random.value > 0.5f ?
                Random.Range(-10f, -12f) :
                Random.Range(10f, 12f);
            var SShip = (GameObject)Instantiate(SShipPrefab, offset, Quaternion.identity);
            timer = 0f;
            SShipCounter += 1;
        }
    }
}
