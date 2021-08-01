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
        
        if (_currentItem != null)
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
        if (_currentItem != null)
        {
            Destroy(_currentItem);
            ItemRemoved.Invoke(_currentItem);
        }
    }
    public void DropItemFromHand()
    {
        if (_currentItem != null)
        {
            _currentItem.transform.parent = null;
            _currentItem.AddComponent<Rigidbody>();
            ItemRemoved.Invoke(_currentItem);
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
