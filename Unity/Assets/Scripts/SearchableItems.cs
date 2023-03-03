using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchableItems : MonoBehaviour
{
    List<SearchableItem> items = new List<SearchableItem>();

    // Start is called before the first frame update
    void Start()
    {
        items = GetComponentsInChildren<SearchableItem>().ToList();
    }
}
