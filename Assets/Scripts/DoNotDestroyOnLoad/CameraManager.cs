using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        GameManager.Instance.CanvasInventory.gameObject.GetComponent<Canvas>().worldCamera = GetComponent<Camera>();
    }
    
    private void Update()
    {
        GameObject[] dontdestroyonloadObjects = GameObject.FindGameObjectsWithTag("MainCamera");
    
        if (dontdestroyonloadObjects.Length > 1)
        {
            Destroy(dontdestroyonloadObjects[1]);
        }
    }
}
