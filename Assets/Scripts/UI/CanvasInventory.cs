using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : MonoBehaviour
{
    [SerializeField] private GameObject _prefabItem;
    [SerializeField] private GameObject _panel;

    public GameObject selectedItem;

    public void AddItem(Item item, Sprite sprite, int type)
    {
        GameObject newItem = Instantiate(_prefabItem, _panel.transform, false);
        newItem.GetComponent<ItemUi>().Initialize(item);
        newItem.GetComponent<Image>().sprite = sprite;
        newItem.GetComponent<ItemUi>().type = type;
    }
}
