using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    public UnityEvent<GameObject> ItemRemoved;

    private GameObject _currentItem;
    
    public void PlaceItemToHand(GameObject item)
    {
        
        if (GetCurrentItem() != null)
        {
            DropItemFromHand();
        }
        _currentItem = PrepareItemToPlacing(item);
        _currentItem.transform.SetParent(transform, false);
        _currentItem.GetComponent<RectTransform>().position = Vector3.zero;
        _currentItem.GetComponent<RectTransform>().localPosition = Vector3.zero;

    }
    public void DestroyItemInHand()
    {
        if (GetCurrentItem() != null)
        {
            ItemRemoved.Invoke(_currentItem);
            Destroy(_currentItem);
        }
    }
    public void DropItemFromHand()
    {
        if (_currentItem != null)
        {
            ItemRemoved.Invoke(_currentItem);
            _currentItem.transform.parent = null;
            _currentItem.AddComponent<Rigidbody>(); 
        }
    } 
    private GameObject PrepareItemToPlacing(GameObject item)
    {
        Destroy(item.GetComponent<Image>());
        Destroy(item.GetComponent<CanvasRenderer>());
        return item;
    }
    public GameObject GetCurrentItem()
    {
        return _currentItem;
    }
}
