using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : MonoBehaviour
{
    [SerializeField] private GameObject _prefabItem;
    [SerializeField] private GameObject _panel;

    public GameObject selectedItem;

    public void AddItem(Item item, Sprite sprite, Sprite sprite2, int type)
    {
        if (sprite2 == null)
        {
            GameObject newItem = Instantiate(_prefabItem, _panel.transform, false);
            newItem.GetComponent<ItemUi>().Initialize(item);
            newItem.GetComponent<Image>().sprite = sprite;
            newItem.GetComponent<ItemUi>().type = type;
        }
        else
        {
            GameObject newItem1 = Instantiate(_prefabItem, _panel.transform, false);
            newItem1.GetComponent<ItemUi>().Initialize(item);
            newItem1.GetComponent<Image>().sprite = sprite;
            newItem1.GetComponent<ItemUi>().type = type;
            
            GameObject newItem2 = Instantiate(_prefabItem, _panel.transform, false);
            newItem2.GetComponent<ItemUi>().Initialize(item);
            newItem2.GetComponent<Image>().sprite = sprite2;
            newItem2.GetComponent<ItemUi>().type = type;
        }
    }
}