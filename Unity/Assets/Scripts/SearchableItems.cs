using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SearchableItems : MonoBehaviour
{
    public GameObject SearchableItemPrefab;

    List<SearchableItem> items = new List<SearchableItem>();

    // Start is called before the first frame update
    void Start()
    {
        CreateNewSearchableItem();
        GameEvents.PlayerCollectedItem += OnPlayerCollectedItem;
    }

    private void CreateNewSearchableItem()
    {
        Vector3 randPos = GetRandomPositionOnMap(new Vector3(20f, 20f, 20f));
        Instantiate(SearchableItemPrefab, randPos, Quaternion.identity, transform);
    }

    private void OnPlayerCollectedItem()
    {
        CreateNewSearchableItem();
    }

    public Vector3 GetRandomPositionOnMap(Vector3 extents)
    {
        Vector3 randomPosition = new Vector3(Random.Range(-extents.x, extents.x), 0, Random.Range(-extents.z, extents.z));

        RaycastHit hit;
        if (Physics.Raycast(randomPosition + Vector3.up * 100f, Vector3.down, out hit, 100f * 2))
        {
            return hit.point;
        }

        return randomPosition;
    }
}
