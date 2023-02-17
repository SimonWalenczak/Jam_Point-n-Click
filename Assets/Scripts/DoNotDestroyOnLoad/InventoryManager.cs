using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    private void Update()
    {
        GameObject[] dontdestroyonloadObjects = GameObject.FindGameObjectsWithTag("Inventory");
    
        if (dontdestroyonloadObjects.Length > 1)
        {
            Destroy(dontdestroyonloadObjects[1]);
        }
    }
}
