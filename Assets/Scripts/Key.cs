using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, ITakable
{
    [SerializeField]
    private int _keyID;
    [SerializeField]
    private Sprite _keyTexture;

    public Sprite GetKeyTexture()
    {
        return _keyTexture;
    }
    public void SetKeyTexture(Sprite keyTexture)
    {
        _keyTexture = keyTexture;
    }
    public void SetID(int keyID)
    {
        _keyID = keyID;
    }
    public int GetKeyID()
    {
        return _keyID;
    }
}
