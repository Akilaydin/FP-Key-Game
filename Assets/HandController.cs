using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private GameObject _currentItem;
    public void PlaceItemToHand(GameObject item)
    {
        
        if (_currentItem != null)
        {
            RemoveItemFromHand();
        }
        _currentItem = item;
        _currentItem.transform.SetParent(transform, false);
    }
    public void RemoveItemFromHand()
    {
        if (_currentItem != null)
        {
            Destroy(_currentItem);
        }
    } 
}
