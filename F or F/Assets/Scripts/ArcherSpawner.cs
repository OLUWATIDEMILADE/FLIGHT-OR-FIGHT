using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcherSpawner : MonoBehaviour
{
    [Header("Archer Setup")]
    public GameObject archerPrefab;
    public Transform[] treeSpawnPoints;
    public float distanceInFront = 3f; // how far from the tree the archer spawns
    public float nextWaveDelay = 25f;

    private List<GameObject> currentArchers = new List<GameObject>();

    void Start()
    {
        SpawnArchers();
    }

    void Update()
    {
        // Check if all current archers are destroyed
        if (currentArchers.Count > 0)
        {
            currentArchers.RemoveAll(item => item == null); // clean up destroyed archers

            if (currentArchers.Count == 0)
            {
                // Start coroutine to spawn next wave after delay
                StartCoroutine(SpawnNextWaveAfterDelay());
            }
        }
    }

    void SpawnArchers()
    {
        if (archerPrefab == null || treeSpawnPoints.Length == 0) return;

        currentArchers.Clear();

        for (int i = 0; i < treeSpawnPoints.Length; i++)
        {
            Vector3 spawnPos = treeSpawnPoints[i].position + treeSpawnPoints[i].forward * distanceInFront;
            GameObject archer = Instantiate(archerPrefab, spawnPos, Quaternion.identity);
            currentArchers.Add(archer);
        }
    }

    IEnumerator SpawnNextWaveAfterDelay()
    {
        // Prevent multiple coroutines running simultaneously
        if (currentArchers.Count == 0)
        {
            yield return new WaitForSeconds(nextWaveDelay);
            SpawnArchers();
        }
    }
}
