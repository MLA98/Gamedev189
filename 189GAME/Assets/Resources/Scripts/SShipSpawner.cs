﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SShipSpawner : MonoBehaviour
{
    public GameObject SShipPrefab;

    private float spawnRate;
    private float timer;
    private float SShipCounter;
    private float waveLimit;
    
    private GameManager instance;
   
    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        waveLimit = instance.Wave * 2;
        spawnRate = 20 + 0.1f * (instance.Wave - 1);
        timer += Time.deltaTime;
        if (timer >= spawnRate && instance.currState == GameManager.gameState.playing && SShipCounter <= waveLimit)
        {
            // Offset at corners of the screen
            Vector3 offset;
            offset.x = Random.value > 0.5f ?
                Random.Range(-4f, -3f) :
                Random.Range(3f, 4f);
            offset.y = 0f;
            offset.z = Random.value > 0.5f ?
                Random.Range(-5f, -4f) :
                Random.Range(4f, 5f);
            var SShip = (GameObject)Instantiate(SShipPrefab, offset, Quaternion.identity);
            timer = 0f;
            SShipCounter += 1;
        }
    }
}
