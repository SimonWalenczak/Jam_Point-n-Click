using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field:SerializeField] public string Name { get; private set; }

    public void Execute()
    {
        GameManager.Instance.AddItem(this);
        Destroy(gameObject);
    }
}
