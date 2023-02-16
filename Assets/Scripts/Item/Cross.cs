using UnityEngine;

public class Cross : MonoBehaviour
{
    [SerializeField] private GameObject itemMarkPanel;
    public PlayerController _playerController;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            itemMarkPanel.SetActive(false);
            _playerController.CanMove = true;
            GameManager.Instance.ResetPosItemMark();
        }
    }
}