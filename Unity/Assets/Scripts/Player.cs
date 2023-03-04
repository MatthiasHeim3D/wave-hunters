using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputActionReference CollectItem;

    private void Start()
    {
        CollectItem.action.performed += CollectItem_performed;

        GameEvents.PlayerCollectedItem += OnPlayerCollectedItem;
    }

    private void OnPlayerCollectedItem()
    {
        Debug.Log("Item Collected");

    }

    private void CollectItem_performed(InputAction.CallbackContext obj)
    {
        GameEvents.PlayerCollectItem?.Invoke();
    }
}
