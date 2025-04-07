using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointsContainer : MonoBehaviour
{
    public List<SpawnPoint> GetPoints()
    {
        return GetComponentsInChildren<SpawnPoint>().ToList<SpawnPoint>();
    }
}
