using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //initialize variables
    private int rounds = 0;
    private int enemyCount = 0;
    private float spawnRate = 1.0f;
    private bool spawnDoor = false;

    //list of enemy prefabs to choose from
    public List<GameObject> enemyPrefabs;

    //reference to door prefab
    public GameObject doorPrefab;

    //array of spawn points for enemies and door
    public Transform[] spawnPoints;

    void Start()
    {
        //start the game loop
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        //loop until the door has been spawned
        while (!spawnDoor)
        {
            //spawn enemies based on the number of rounds
            switch (rounds)
            {
                case 0:
                    enemyCount = 1;
                    SpawnEnemies();
                    break;

                case 1:
                    enemyCount = 2;
                    SpawnEnemies();
                    break;

                case 2:
                    enemyCount = 3;
                    SpawnEnemies();
                    break;

                case 3:
                    enemyCount = 4;
                    SpawnEnemies();
                    break;

                case 4:
                    enemyCount = 5;
                    SpawnEnemies();
                    break;

                case 5:
                    SpawnDoor();
                    spawnDoor = true;
                    break;
            }

            //increase enemy count and spawn rate every round
            enemyCount++;
            spawnRate *= 1.2f;

            //wait for enemies to be defeated
            while (EnemiesRemaining())
            {
                yield return new WaitForSeconds(0.1f);
            }

            //increase round count
            rounds++;
        }
    }

    //function to spawn enemies
    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            //choose a random enemy prefab from the list
            int index = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = Instantiate(enemyPrefabs[index], GetSpawnPosition(), Quaternion.identity);
        }
    }

    //function to get a random spawn position from the array of spawn points
    Vector3 GetSpawnPosition()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index].position;
    }

    //function to check if there are enemies remaining
    bool EnemiesRemaining()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length > 0;
    }

    //function to spawn a door
    void SpawnDoor()
    {
        GameObject door = Instantiate(doorPrefab, GetSpawnPosition(), Quaternion.identity);
    }
}
