using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRate = 1f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate && !GameManager.instance.gameOver)
        {
            Vector3 offset;
            offset.x = Random.value > 0.5f ?
                Random.Range(-8f, -10f) :
                Random.Range(8f, 10f);
            offset.y = 0f;
            offset.z = Random.value > 0.5f ?
                Random.Range(-10f, -12f) :
                Random.Range(10f, 12f);
            var enemy = (GameObject)Instantiate(enemyPrefab, offset, Quaternion.identity);
            timer = 0f;
        }
    }
}
