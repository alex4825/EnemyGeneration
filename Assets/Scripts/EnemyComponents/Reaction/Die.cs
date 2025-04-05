using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : IReactionBehavior
{
    public void ProcessReaction(Enemy enemy, Player player)
    {
        float distanceToPlayer = (player.transform.position - enemy.transform.position).magnitude;

        if (distanceToPlayer < enemy.DetectionRadius)
        {
            enemy.DestroySelf();
        }
    }
}
