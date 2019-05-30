using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bigEnemyPrefab;
    public GameObject tinyEnemyPrefab;
    private float spawnRate;
    private float timer;
    private float enemyCounter;
    private float waveLimit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        waveLimit = GameManager.instance.Wave * 25;
        spawnRate = 3 - 0.1f * (GameManager.instance.Wave - 1);
        timer += Time.deltaTime;
        if (timer >= spawnRate && GameManager.instance.currState == GameManager.gameState.playing && enemyCounter <= waveLimit)
        {
            Vector3 offset;
            offset.x = Random.value > 0.5f ?
                Random.Range(-8f, -10f) :
                Random.Range(8f, 10f);
            offset.y = 0f;
            offset.z = Random.value > 0.5f ?
                Random.Range(-10f, -12f) :
                Random.Range(10f, 12f);
            if (GameManager.instance.Wave <= 2)
            {
                var enemy = (GameObject)Instantiate(enemyPrefab, offset, Quaternion.identity);
            }
            else if (GameManager.instance.Wave > 2 && GameManager.instance.Wave <= 4)
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
            else if (GameManager.instance.Wave > 4)
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
        if (enemyCounter > waveLimit && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            GameManager.instance.currState = GameManager.gameState.waveCompleted;
            enemyCounter = 0;
        }
    }
}
