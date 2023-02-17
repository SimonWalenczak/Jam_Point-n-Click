using UnityEngine;

public class ItemUi : MonoBehaviour
{
    public void Initialize(Item item)
    {
        GetComponentInChildren<TMPro.TMP_Text>().text = item.Name;
    }
}
