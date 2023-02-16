using DG.Tweening;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] private bool _isUp = false;
    [SerializeField] private Vector2 pos;

    public PlayerController _playerController;
    private void OnMouseOver()
    {
        if (_isUp == false)
        {
            _isUp = true;
            transform.DOMoveY(pos.x, 1);
            _playerController.CanMove = false;
        }
    }

    private void OnMouseExit()
    {
        if (_isUp == true)
        {
            _isUp = false;
            transform.DOMoveY(pos.y, 1);
            _playerController.CanMove = true;
        }
    }
}