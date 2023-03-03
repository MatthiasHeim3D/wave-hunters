using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableItem : MonoBehaviour
{
    public Vector2 audioRange = new Vector2(0f, 10f);
    StudioEventEmitter emitter;

    bool playerMovedThisFrame = false;
    Vector3 lastPos;

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
        float lastDist = Vector3.Distance(playerPos, transform.position);
        float distNormalized = lastDist.Remap(audioRange.x, audioRange.y, 0f, 1f);
        emitter.SetParameter("Distance", distNormalized);

        Debug.Log($"lastpos: {lastDist}");

        lastPos = playerPos;
        playerMovedThisFrame = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        if (playerMovedThisFrame)
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawLine(transform.position, lastPos);
    }
}

