using UnityEngine;

public class ValueDontDestroyOnLoad : MonoBehaviour
{
    public static ValueDontDestroyOnLoad instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
}
