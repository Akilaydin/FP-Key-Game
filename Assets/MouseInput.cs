using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseInput : MonoBehaviour
{
    public UnityEvent<GameObject> KeySelected;

    [SerializeField]
    private GraphicRaycaster _graphicRaycaster;

    private bool _canSelect = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canSelect == true)
        {
            Debug.Log(_canSelect);
            PointerEventData pointerEventData = new PointerEventData(null);
            pointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(pointerEventData, results);

            if (results.Count > 0 && results.Count < 2)
            {
                if (results[0].gameObject.GetComponent<Key>())
                {
                    GameObject card = results[0].gameObject;
                    KeySelected.Invoke(card);
                }
            }
        }
    }
    public void OnStateSwitch(PlayerState playerState)
    {
        switch (playerState)
        {
            case PlayerState.InventoryMode:
                _canSelect = true;
                break;
            case PlayerState.PlayMode:
                _canSelect = false;
                break;
        }
    }
}
