using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public UnityEvent ItemAdded;
    public UnityEvent ItemRemoved;
    [SerializeField]
    private int _maxItemsInInventory = 2;
    [Range(0.01f,5f)]
    [SerializeField]
    private float _hotbarItemTextureScale = 0.7f;
    [SerializeField]
    private Transform _hotbar;

    private List<GameObject> _inventoryItems;
    private int _currentItems = 0;
    
    private void Start()
    {
        _inventoryItems = new List<GameObject>();
        ItemAdded.AddListener(RefreshHotbar);
        ItemRemoved.AddListener(RefreshHotbar);
    }

    private void AddItemToHotbar(GameObject item)
    {
        Instantiate(item, _hotbar);
    }

    public bool AddKeyToInventory(GameObject inventoryItem)
    {
        if (CompareKeys(inventoryItem) == false && _inventoryItems.Count < _maxItemsInInventory)
        {
            inventoryItem.AddComponent<Image>().sprite = inventoryItem.GetComponent<Key>().GetKeyTexture();
            inventoryItem.GetComponent<RectTransform>().localScale = new Vector3(_hotbarItemTextureScale,_hotbarItemTextureScale,_hotbarItemTextureScale);
            inventoryItem.GetComponent<RectTransform>().rotation = Quaternion.identity;
            _inventoryItems.Add(inventoryItem);
            _currentItems++;
            ItemAdded.Invoke();
            return true;
        }
        else
        {
            Debug.Log(inventoryItem + " is already in inventory or there isn't enough space");
            return false;
        }
    }
    public void RemoveKeyFromInventory(GameObject inventoryItem)
    {
        if (CompareKeys(inventoryItem) == true)
        {
            _inventoryItems.RemoveAll(x => x.GetComponent<Key>().GetKeyID() == inventoryItem.GetComponent<Key>().GetKeyID());
            ItemRemoved.Invoke();
        }
    }
    private bool CompareKeys(GameObject key) //Returns true if there is already an exact same key in inventory
    {
        foreach (var item in _inventoryItems)
        {
            if (item == null)
            {
                return false;
            }
            if (item.GetComponent<Key>().GetKeyID() == key.GetComponent<Key>().GetKeyID())
            {
                return true;
            }
        }
        return false;
    }
    private void RefreshHotbar()
    {
        foreach (GameObject inventoryObject in _inventoryItems)
        {
            if (inventoryObject != null)
            {
                AddItemToHotbar(inventoryObject);
            }
        }
    }
}
