using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    int maxEnemiesSpawnedAtOnce = 10;

    [SerializeField]
    GameObject fastEnemy;

    [SerializeField]
    GameObject slowEnemy;

    [SerializeField]
    bool isSpawning = false;
    
    [SerializeField]
    int numOfFastEnemiesToSpawn;

    [SerializeField]
    int numOfSlowEnemiesToSpawn;

    List<GameObject> enemySpawnPoints = new List<GameObject>();

	// Use this for initialization
	void Start () {
        enemySpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("EnemySpawnPoint"));
	}
	
	// Update is called once per frame
	void Update () {
        if (isSpawning)
        {
            if (EnemiesRemaining() < maxEnemiesSpawnedAtOnce)
            {
                SpawnEnemy();
            }
        }

        if(numOfFastEnemiesToSpawn == 0 && numOfSlowEnemiesToSpawn == 0)
        {
            isSpawning = false;
        }
	}

    public bool GetAreEnemiesSpawning()
    {
        return isSpawning;
    }

    public void SetAreEnemiesSpawning(bool _isSpawning)
    {
        isSpawning = _isSpawning;
    }

    public void EnemiesToSpawn(int _fastEnemiesToSpawn, int _slowEnemiesToSpawn)
    {
        numOfFastEnemiesToSpawn = _fastEnemiesToSpawn;
        numOfSlowEnemiesToSpawn = _slowEnemiesToSpawn;
    }

    int EnemiesRemaining()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length;
    }

    void SpawnEnemy()
    {
        GameObject spawnPoint = ChooseSpawnPoint();

        if(spawnPoint != null)
        {
            GameObject toSpawn = ChooseEnemyToSpawn();
            if(toSpawn != null)
            {
                GameObject spawnedEnemy = Instantiate(toSpawn, spawnPoint.transform.position, Quaternion.identity);
                if(spawnedEnemy != null)
                {
                    GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                    if(playerObject != null)
                    {
                        Transform player = playerObject.transform;
                        spawnedEnemy.GetComponent<EnemyAIController>().SetTarget(player);
                        spawnedEnemy.GetComponent<EnemyHealth>().lootToDrop = ItemManager.instance.ChooseItemToDrop();
                    }                    
                }

            }
        }
    }

    GameObject ChooseSpawnPoint()
    {
        int spawnPointToPick = Random.Range(0, enemySpawnPoints.Count);

        if (enemySpawnPoints[spawnPointToPick] != null)
        {
            if (!enemySpawnPoints[spawnPointToPick].GetComponent<SpawnPoint>().GetIsOccupied())
            {
                return enemySpawnPoints[spawnPointToPick];
            } else
            {
                return ChooseSpawnPoint();
            }
        }

        return null;
    }

    GameObject ChooseEnemyToSpawn()
    {
        float probabilityOfFastEnemy = Random.Range(0f, 1f);

        if(probabilityOfFastEnemy > 0.5f)
        {
            if(numOfFastEnemiesToSpawn > 0)
            {
                numOfFastEnemiesToSpawn -= 1;
                return fastEnemy;
            } else if(numOfSlowEnemiesToSpawn > 0)
            {
                    numOfSlowEnemiesToSpawn -= 1;
                    return slowEnemy;
            }            
           
        } else if(probabilityOfFastEnemy <= 0.5f)
        {
            if (numOfSlowEnemiesToSpawn > 0)
            {
                numOfSlowEnemiesToSpawn -= 1;
                return slowEnemy;
            } else if (numOfFastEnemiesToSpawn > 0)
            {
                numOfFastEnemiesToSpawn -= 1;
                return fastEnemy;
            }
        }

        return null;
    }
}
