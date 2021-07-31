using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public UnityEvent<GameObject> ItemAdded;
    public UnityEvent ItemRemoved;

    [SerializeField]
    private Transform _hotbar;

    private List<GameObject> _inventoryObjects;
    
    private void Start()
    {
        _inventoryObjects = new List<GameObject>();
        ItemAdded.AddListener(AddItemToHotbar);
        ItemRemoved.AddListener(RefreshHotbar);
    }

    private void AddItemToHotbar(GameObject item)
    {
        Instantiate(item, _hotbar);
    }

    public void AddKeyToInventory(GameObject inventoryItem)
    {
        if (_inventoryObjects.Contains(inventoryItem) == false)
        {
            inventoryItem.AddComponent<Image>().sprite = inventoryItem.GetComponent<Key>().GetKeyTexture();
            _inventoryObjects.Add(inventoryItem);
            ItemAdded.Invoke(inventoryItem);
        }
        else
        {
            Debug.Log("The key already in inventory");
        }
    }
    public void RemoveKeyFromInventory(GameObject inventoryItem)
    {
        if (_inventoryObjects.Contains(inventoryItem) == true)
        {
            _inventoryObjects.Remove(inventoryItem);
            ItemRemoved.Invoke();
        }
    }
    private void RefreshHotbar()
    {
        foreach (GameObject inventoryObject in _inventoryObjects)
        {
            Instantiate(inventoryObject, _hotbar);
        }
    }
}
