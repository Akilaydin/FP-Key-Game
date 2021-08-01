using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public UnityEvent ItemAdded;
    public UnityEvent ItemRemoved;
    [Range(0.01f,5f)]
    [SerializeField]
    private float _hotbarItemTextureScale = 0.7f;
    [SerializeField]
    private Transform _hotbar;

    private List<GameObject> _inventoryObjects;
    
    private void Start()
    {
        _inventoryObjects = new List<GameObject>();
        ItemAdded.AddListener(RefreshHotbar);
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
            inventoryItem.GetComponent<RectTransform>().localScale = new Vector3(_hotbarItemTextureScale,_hotbarItemTextureScale,_hotbarItemTextureScale);
            inventoryItem.GetComponent<RectTransform>().rotation = Quaternion.identity;
            _inventoryObjects.Add(inventoryItem);
            ItemAdded.Invoke();
        }
        else
        {
            Debug.Log(inventoryItem + " is already in inventory");
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
            if (inventoryObject != null)
            {
                AddItemToHotbar(inventoryObject);
            }
        }
    }
}
