using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bigEnemyPrefab;
    public GameObject tinyEnemyPrefab;
    public GameObject bossPrefab;
    private float spawnRate;
    private float timer;
    private float enemyCounter;
    private float waveLimit;
    private bool boss = false;
    private GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.Wave < 8)
        {
            // Increasing difficulty per wave
            waveLimit = instance.Wave * 12;
            spawnRate = 2 - 0.1f * (instance.Wave - 1);
            timer += Time.deltaTime;
            if (timer >= spawnRate && instance.currState == GameManager.gameState.playing && enemyCounter <= waveLimit)
            {
                // Spawn out of camera range
                Vector3 offset;

                if (Random.value > 0.5f)
                {
                    offset.x = Random.value > 0.5f ?
                        Random.Range(-8f, -10f) :
                        Random.Range(8f, 10f);
                    offset.y = 0f;
                    offset.z = Random.Range(-12f, 12f);
                }
                else
                {
                    offset.x = Random.Range(-10f, 10f);
                    offset.y = 0f;
                    offset.z = Random.value > 0.5f ?
                        Random.Range(-10f, -12f) :
                        Random.Range(10f, 12f);
                }
                // Spawn RNG for different waves
                if (instance.Wave <= 2)
                {
                    var enemy = (GameObject)Instantiate(enemyPrefab, offset, Quaternion.identity);
                }
                else if (instance.Wave > 2 && instance.Wave <= 4)
                {
                    float rand = Random.Range(0, 10);
                    if (rand <= 7)
                    {
                        var enemy = (GameObject)Instantiate(enemyPrefab, offset, Quaternion.identity);
                    }
                    else if (rand > 7)
                    {
                        var enemy = (GameObject)Instantiate(bigEnemyPrefab, offset, Quaternion.identity);
                    }
                }
                else if (instance.Wave > 4)
                {
                    float rand = Random.Range(0, 10);
                    if (rand <= 4)
                    {
                        var enemy = (GameObject)Instantiate(enemyPrefab, offset, Quaternion.identity);
                    }
                    else if (rand > 4 && rand <= 7.5)
                    {
                        var enemy = (GameObject)Instantiate(bigEnemyPrefab, offset, Quaternion.identity);
                    }
                    else if (rand > 7.5)
                    {
                        var enemy = (GameObject)Instantiate(tinyEnemyPrefab, offset, Quaternion.identity);
                    }
                }
                timer = 0f;
                enemyCounter += 1;
            }
            // Wave is completed if all enemies spawned and destroyed
            if (enemyCounter > waveLimit && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                instance.currState = GameManager.gameState.waveCompleted;
                enemyCounter = 0;
            }
        }
        // Boss at wave 8
        if (instance.Wave == 8 && !boss)
        {
            Vector3 offset = new Vector3(0, 0, 18);
            var enemy = (GameObject)Instantiate(bossPrefab, offset, Quaternion.identity);
            boss = true;
        }
        // Win if boss is killed
        if (boss && GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && instance.currState != GameManager.gameState.gameOver)
        {
            instance.currState = GameManager.gameState.won;
        }
    }
}
