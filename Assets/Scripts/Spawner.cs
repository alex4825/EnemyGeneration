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

            ChooseIdleBehavior(newEnemy, spawnPoint, spawnPoints);

            ChooseReactionBehavior(newEnemy, spawnPoint, spawnPoints);
        }

        return enemies;
    }

    private void ChooseIdleBehavior(Enemy enemy, SpawnPoint currentPoint, List<SpawnPoint> points)
    {
        switch (currentPoint.IdleBehavior)
        {
            case IdleBehaviors.Wait:
                enemy.Set(new Wait());
                break;

            case IdleBehaviors.PointsPatrol:
                enemy.Set(new PointsPatrol(points));
                break;

            case IdleBehaviors.RardomPatrol:
                enemy.Set(new RandomPatrol());
                break;
        }
    }

    private void ChooseReactionBehavior(Enemy enemy, SpawnPoint currentPoint, List<SpawnPoint> points)
    {
        switch (currentPoint.ReactionBehavior)
        {
            case ReactionBehaviors.CatchingUp:
                enemy.Set(new CatchUp());
                break;

            case ReactionBehaviors.RunningAway:
                enemy.Set(new RunAway());
                break;

            case ReactionBehaviors.Die:
                enemy.Set(new Die());
                break;
        }
    }

}
