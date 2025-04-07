using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Player _player;

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
                enemy.SetIdle(new Wait());
                break;

            case IdleBehaviors.PointsPatrol:
                enemy.SetIdle(new PointsPatrol(enemy.Mover, points));
                break;

            case IdleBehaviors.RardomPatrol:
                enemy.SetIdle(new RandomPatrol(enemy.Mover));
                break;
        }
    }

    private void ChooseReactionBehavior(Enemy enemy, SpawnPoint currentPoint, List<SpawnPoint> points)
    {
        switch (currentPoint.ReactionBehavior)
        {
            case ReactionBehaviors.CatchingUp:
                enemy.SetReaction(new CatchUp(enemy.Mover, _player.transform));
                break;

            case ReactionBehaviors.RunningAway:
                enemy.SetReaction(new RunAway(enemy.Mover, _player.transform));
                break;

            case ReactionBehaviors.Die:
                enemy.SetReaction(new Die(enemy, _player.transform));
                break;
        }
    }
}
