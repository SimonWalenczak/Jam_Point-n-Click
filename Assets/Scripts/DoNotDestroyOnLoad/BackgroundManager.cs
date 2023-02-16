using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        GameObject[] dontdestroyonloadObjects = GameObject.FindGameObjectsWithTag("BG");

        if (dontdestroyonloadObjects.Length > 1)
        {
            Destroy(dontdestroyonloadObjects[1]);
        }
    }
}