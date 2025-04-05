using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : IReactionBehavior
{
    public void ProcessReaction(Enemy enemy, Player player)
    {
        Vector3 directionAwayFromPlayer = (enemy.transform.position - player.transform.position).normalized;

        enemy.Mover.MoveTo(directionAwayFromPlayer);
    }
}
