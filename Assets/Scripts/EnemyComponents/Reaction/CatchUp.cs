using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchUp : IReactionBehavior
{
    public void ProcessReaction(Enemy enemy, Player player)
    {
        Vector3 directionToPlayer = (player.transform.position - enemy.transform.position).normalized;

        enemy.Mover.MoveTo(directionToPlayer);
    }
}
