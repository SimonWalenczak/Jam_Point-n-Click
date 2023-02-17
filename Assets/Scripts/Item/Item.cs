using TMPro;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field: SerializeField] public string Name { get; private set; }

    public Sprite ItemspriteMark;
    public Sprite ItemSprite;
    public Sprite ItemSprite2;


    public int GameStep;
    public bool isItem;

    [SerializeField] private float distDetect;

    public PlayerController _playerController;
    private SpriteRenderer _spriteRenderer;
    private PolygonCollider2D _polygonCollider2D;

    private float dist;
    [SerializeField] private bool isPointed;
    [SerializeField] private bool canBePicked;

    [SerializeField] private int type;
    [SerializeField] private int typeCondition;

    public DontDestroyOnLoad _dontDestroyOnLoad;
    public bool isPoupee;

    private void OnMouseEnter()
    {
        isPointed = true;
    }

    private void OnMouseExit()
    {
        isPointed = false;
    }

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        _dontDestroyOnLoad = FindObjectOfType<DontDestroyOnLoad>();
    }

    public bool ActivationCondition;

    private void Condition()
    {
        switch (typeCondition)
        {
            case 2:
                if (_dontDestroyOnLoad.haveShovel)
                    ActivationCondition = true;
                break;
            case 3:
                if (_dontDestroyOnLoad.haveBattery)
                    ActivationCondition = true;
                break;
            case 4:
                if (_dontDestroyOnLoad.haveEye)
                    ActivationCondition = true;
                break;
            case 5:
                if (_dontDestroyOnLoad.haveSkull)
                    ActivationCondition = true;
                break;
            case 0:
                ActivationCondition = true;
                break;
        }
    }

    public void CalculateDistance()
    {
        dist = Vector3.Distance(gameObject.transform.position, _playerController.transform.position);

        if (isPoupee == false)
        {
            if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep && canBePicked == true && isPointed == true)
            {
                _spriteRenderer.enabled = true;
            }
            else
            {
                _spriteRenderer.enabled = false;
            }
        }
        else
        {
            if (FindObjectOfType<DontDestroyOnLoad>().GameStep < 14 && canBePicked == true && isPointed == true)
            {
                _spriteRenderer.enabled = true;
            }
            else
            {
                _spriteRenderer.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (dist < distDetect)
        {
            canBePicked = true;
        }
        else
        {
            canBePicked = false;
        }

        CalculateDistance();
        Condition();
    }

    public void Execute()
    {
        if (FindObjectOfType<DontDestroyOnLoad>().GameStep <= 13)
        {
            if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep && canBePicked == true &&
                isPointed == true &&
                ActivationCondition == true)
            {
                _dontDestroyOnLoad.ResetBoolAction();
                Destroy(GameManager.Instance.CanvasInventory.selectedItem);

                if (isItem == true)
                {
                    GameManager.Instance.AddItem(this, ItemSprite, ItemSprite2, type);
                    DisplayItemMark();
                    Destroy(gameObject);
                }
                else if (isPoupee == true)
                {
                    FindObjectOfType<DontDestroyOnLoad>().giftSkull = true;

                }
                else
                {
                    Destroy(gameObject);
                    FindObjectOfType<DontDestroyOnLoad>().GameStep++;
                }
            }
        }
    }

    public void DisplayItemMark()
    {
        _playerController.CanMove = false;
        GameManager.Instance.itemMarkPanel.SetActive(true);
        GameManager.Instance.itemMark.SetActive(true);
        GameManager.Instance.ItemSpriteRenderer.sprite = ItemspriteMark;
    }
}