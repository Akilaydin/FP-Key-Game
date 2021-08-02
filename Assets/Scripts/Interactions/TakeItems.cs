using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItems : MonoBehaviour
{
    [Range(0f,10f)]
    [SerializeField]
    private float _takeDistance = 3f;
    [SerializeField]
    private Inventory _inventory;
    List<GameObject> test = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit, _takeDistance))
            {
                GameObject takable = raycastHit.transform.gameObject;
                if (takable.GetComponent<Key>() != null)
                {
                    DestroyImmediate(takable.GetComponent<Rigidbody>());
                    GameObject takableTemp = takable;
                    if (_inventory.AddKeyToInventory(takable))
                    {
                        takable.SetActive(false);
                    }
                    else
                    {
                        return;
                    }
                    
                }
            }
        }
    }
}
