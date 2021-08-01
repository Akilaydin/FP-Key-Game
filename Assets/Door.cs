using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private int _doorID;
    [Range(0.1f,5f)]
    [SerializeField]
    private float timeToPaintBack = 0.5f;
    private bool _isUnlocked = false;

    public bool Unlock(int keyID) //returns true if unlock was successfull. Returns false if the door is already unlocked or used inappropriate key.
    {
        if (_isUnlocked == true) return false;

        if (_doorID == keyID)
        {
            GetComponent<Renderer>().material.color = Color.green;
            _isUnlocked = true;
            return true;
        }
        else
        {
            StartCoroutine(PaintToRed());
            return false;
        }
    }
    
    private IEnumerator PaintToRed()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color initialColor = renderer.material.color;
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(timeToPaintBack);
        renderer.material.color = initialColor;
    }
}
