using UnityEngine;

public class MarkPanel : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    private void Update()
    {
        GameObject[] markPanelObjects = GameObject.FindGameObjectsWithTag("MarkPanel");

        if (markPanelObjects.Length > 1)
        {
            Destroy(markPanelObjects[1]);
        }
    }
}
