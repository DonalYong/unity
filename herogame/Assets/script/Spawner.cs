using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemies;
    public float SpawnTime = 5f;
    public float SpawnDelay = 3f;


    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnEnemy", SpawnDelay, SpawnTime);
    }
    void SpawnEnemy()
    {
        int index = Random.Range(0, Enemies.Length);
        var enemy = Instantiate(Enemies[index], transform.position, transform.localRotation);
        enemy.transform.localScale = new Vector3(-1, 1, 1);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
