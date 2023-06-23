using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<GameObject> spawnPoints = new List<GameObject>();
    public int maxEnemies = 20;
    private float spawnTimer = 60f;
    private float timer;
    [SerializeField]
    private int currentEnemyCount = 0;
    public static Spawner Instance { get; private set; }

    private  GameObject zombie1;
    private  GameObject zombie2;
    private List<GameObject> zombies = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        zombie1 = Resources.Load<GameObject>("Zombie1");
        zombie2 = Resources.Load<GameObject>("Zombie2");
        zombies.Add(zombie1);
        zombies.Add(zombie2);
        foreach (Transform child in transform)
        {
            spawnPoints.Add(child.gameObject);
        }
    }

    private void Start()
    {
        SpawnEnemies(currentEnemyCount);
    }

    private void Update(){
        timer += Time.deltaTime;
        if(timer >= spawnTimer){
            SpawnEnemies(currentEnemyCount);
            if(spawnTimer > 10f){
                spawnTimer -= 5f;
            }
            timer = 0f;
        }
    }
    private void SpawnEnemies(int enemiesRemaining)
    {
        if(enemiesRemaining < maxEnemies){for (int i = 0; i < maxEnemies - enemiesRemaining; i++)
        {
            currentEnemyCount++;
            int spawnPointIdx = UnityEngine.Random.Range(0, spawnPoints.Count);
            int zombieIdx = UnityEngine.Random.Range(0, zombies.Count);
            GameObject spawnPoint = spawnPoints[spawnPointIdx];
            GameObject zombie = zombies[zombieIdx];
            GameObject enemy = Instantiate(zombie, spawnPoint.transform.position, Quaternion.identity);
        }}else{
            spawnTimer += 10f;
        }
    }

    public void EnemyKilled(){
        currentEnemyCount--;
        if(currentEnemyCount <= 0){
            SpawnEnemies(currentEnemyCount);
            if(spawnTimer < 10f){
                spawnTimer = 10f;
            }
        }
    }
}
