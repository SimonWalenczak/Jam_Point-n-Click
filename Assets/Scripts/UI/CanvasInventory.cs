using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : MonoBehaviour
{
    [SerializeField] private GameObject _prefabItem;
    [SerializeField] private GameObject _panel;

    public void AddItem(Item item, Sprite sprite)
    {
        GameObject newItem = Instantiate(_prefabItem, _panel.transform, false);
        newItem.GetComponent<ItemUi>().Initialize(item);
        newItem.GetComponent<Image>().sprite = sprite;
    }
}
