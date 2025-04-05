using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PointsContainer _pointsContainer;
    [SerializeField] private Spawner _spawner;

    private List<SpawnPoint> _spawnPoints;
    private List<Enemy> _enemies;

    private void Awake()
    {
        _spawnPoints = _pointsContainer.GetPoints();
        _enemies = _spawner.SpawnEnemiesIn(_spawnPoints);
    }
}
