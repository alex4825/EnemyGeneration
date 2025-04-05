using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [field: SerializeField]
    public IdleBehaviors IdleBehavior { get; private set; }
    
    [field: SerializeField]
    public ReactionBehaviors Reaction { get; private set; }


}
