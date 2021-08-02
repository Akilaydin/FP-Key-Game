using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public UnityEvent<Door> DoorOpened;
    [Range(0f, 100f)]
    [SerializeField]
    private float _interactDistance = 5f;
    [SerializeField]
    private HandController hand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hand.GetCurrentItem() != null)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, _interactDistance))
            {
                Door door = raycastHit.transform.GetComponent<Door>();
                if (door != null)
                {
                    if (door.Unlock(hand.GetCurrentItem().GetComponent<Key>().GetKeyID()) == true)
                    {
                        DoorOpened.Invoke(door);
                        hand.DestroyItemInHand();
                    }
                }
            }
        }
    }
}
