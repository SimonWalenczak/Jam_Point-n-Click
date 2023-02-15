using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] private bool isDetector;

    public GameObject inventory;
    private void Update()
    {

        if (isDetector)
        {
            inventory.transform.DOMoveY(transform.position.y + 1, 1);
        }
        else
        {
            inventory.transform.DOMoveY(transform.position.y - 1, 1);
        }
    }
}
