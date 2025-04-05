using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public List<Enemy> SpawnEnemiesIn(List<SpawnPoint> spawnPoints)
    {
        List<Enemy> enemies = new List<Enemy>(spawnPoints.Count);

        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            Enemy newEnemy = Instantiate(_enemyPrefab, spawnPoint.transform);
            enemies.Add(newEnemy);
        }

        return enemies;
    }
}
