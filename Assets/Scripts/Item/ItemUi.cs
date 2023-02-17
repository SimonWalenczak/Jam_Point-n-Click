using System;
using UnityEngine;

public class ItemUi : MonoBehaviour
{
    public DontDestroyOnLoad _dontDestroyOnLoad;
    public int type;
    private void Awake()
    {
        _dontDestroyOnLoad = FindObjectOfType<DontDestroyOnLoad>();
    }

    public void Initialize(Item item)
    {
        GetComponentInChildren<TMPro.TMP_Text>().text = item.Name;
    }

    public void Activation()
    {
        switch (type)
        {
            case 1:
                _dontDestroyOnLoad.haveShovel = true;
                break;
            case 2:
                _dontDestroyOnLoad.haveEye = true;
                break;
            case 3:
                _dontDestroyOnLoad.haveBattery = true;
                break;
            case 4:
                _dontDestroyOnLoad.haveSkull = true;
                break;
        }
    }
}
