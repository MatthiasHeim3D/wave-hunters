using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SearchableItem : MonoBehaviour
{
    public Vector2 audioRange = new Vector2(0f, 10f);
    public float InteractDistance = 0.8f;
    public StudioEventEmitter BuzzEmitter;

    public EventReference CollectedEvent;

    bool playerMovedThisFrame = false;
    Vector3 lastPos;
    float lastDist;

    private void Start()
    {
        GameEvents.PlayerMoved += OnPlayerMoved;
        GameEvents.PlayerCollectItem += OnPlayerCollectItem;
    }

    private void OnDestroy()
    {
        GameEvents.PlayerMoved -= OnPlayerMoved;
        GameEvents.PlayerCollectItem -= OnPlayerCollectItem;
    }

    private void OnPlayerMoved(Vector3 playerPos)
    {
        lastDist = Vector3.Distance(playerPos, transform.position);
        float distNormalized = lastDist.Remap(audioRange.x, audioRange.y, 0f, 1f);
        BuzzEmitter.SetParameter("Distance", distNormalized);

        //Debug.Log($"lastpos: {lastDist}");

        lastPos = playerPos;
        playerMovedThisFrame = true;
    }

    private void OnPlayerCollectItem()
    {
        if (lastDist <= InteractDistance)
        {
            GameEvents.PlayerCollectedItem?.Invoke();
            FMODUnity.RuntimeManager.PlayOneShot(CollectedEvent, transform.position);
            BuzzEmitter.Stop();
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        if (playerMovedThisFrame)
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawLine(transform.position, lastPos);
        Handles.Label(transform.position + Vector3.up * 0.25f, $"{lastDist.ToString("#.##")} m");
    }
}

