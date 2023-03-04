using System;
using UnityEngine;

public static class GameEvents
{
    // Player Position
    public static Action<Vector3> PlayerMoved;
    public static Action PlayerCollectItem;
    public static Action PlayerCollectedItem;
}
