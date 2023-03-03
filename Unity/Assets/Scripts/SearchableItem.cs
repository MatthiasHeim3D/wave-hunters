using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableItem : MonoBehaviour
{
    StudioEventEmitter emitter;

    bool playerMovedThisFrame = false;

    private void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();

        GameEvents.PlayerMoved += OnPlayerMoved;
    }
    private void OnDestroy()
    {
        GameEvents.PlayerMoved -= OnPlayerMoved;
    }

    private void OnPlayerMoved(Vector3 playerPos)
    {
        float distance = Vector3.Distance(playerPos, transform.position);
        emitter.SetParameter("Distance", distance);

        playerMovedThisFrame = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        if (playerMovedThisFrame)
        {
            Gizmos.color = Color.green;
        }
    }
}
