using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : GameManager
{
    public GameObject obstaclePrefab;
    private readonly Vector3 spawnPos = new(25, 1, 0);
    private readonly float startDelay = 2;
    private readonly float repeatRate = 2;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        if (IsGameOver())
        {
            CancelInvoke(nameof(SpawnObstacle));
            return;
        }

        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
