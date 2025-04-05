using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PointsContainer _pointsContainer;

    private List<SpawnPoint> _spawnPoints;

    private void Awake()
    {
        _spawnPoints = _pointsContainer.GetPoints();
    }
}
