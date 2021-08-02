using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinChecker : MonoBehaviour
{
    public UnityEvent Won;
    [SerializeField]
    private GameObject _winPanel;

    private List<Door> _closedDors;
    private UnityEvent DoorRemoved;
    private int _doorsToOpen;
    
    private void Start()
    {
        DoorRemoved = new UnityEvent();
        DoorRemoved.AddListener(CheckWin);
        _closedDors = new List<Door>();
        _closedDors.AddRange(FindObjectsOfType<Door>());
        _doorsToOpen = _closedDors.Count;
    }
    public void RemoveDoorFromClosed(Door door)
    {
        if (_closedDors.Contains(door))
        {
            _closedDors.Remove(door);
            _doorsToOpen--;
            DoorRemoved.Invoke();
        }
    }
    private void CheckWin()
    {
        if (_doorsToOpen <= 0)
        {
            Win();
        }
    }
    private void Win()
    {
        _winPanel.SetActive(true);
        Won.Invoke();
    }
}
