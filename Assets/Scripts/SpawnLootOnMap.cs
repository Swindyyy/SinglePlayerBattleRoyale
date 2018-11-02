using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLootOnMap : MonoBehaviour {

    float percentOfSpawnPointsActive = 100f;

    List<GameObject> lootSpawnPoints = new List<GameObject>();

    void Awake()
    {
        lootSpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("LootSpawnPoint"));
    }

	// Use this for initialization
	void Start () {
        int numOfPiecesOfLootToSpawn = (int)((lootSpawnPoints.Count / percentOfSpawnPointsActive) * 100f);

        for(int i = 0; i < numOfPiecesOfLootToSpawn; i++)
        {
            Ingredient itemToDrop = ItemManager.instance.ChooseItemToDrop();
            itemToDrop.CreateItem(lootSpawnPoints[i].transform.position);
        }
	}
}
