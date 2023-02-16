using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field: SerializeField] public string Name { get; private set; }
    
    public Sprite Itemsprite;
    
    public int GameStep;
    public bool isItem;

    [SerializeField] private float distDetect;

    public PlayerController _playerController;
    private SpriteRenderer _spriteRenderer;
    private PolygonCollider2D _polygonCollider2D;

    private float dist;
    [SerializeField] private bool isPointed;
    [SerializeField] private bool canBePicked;


    private void OnMouseEnter()
    {
        print("mouse enter");
        isPointed = true;
    }

    private void OnMouseExit()
    {
        print("mouse exit");
        isPointed = false;
    }

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    public void CalculateDistance()
    {
        dist = Vector3.Distance(gameObject.transform.position, _playerController.transform.position);
        
        if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep && canBePicked == true && isPointed == true)
        {
            _spriteRenderer.enabled = true;
            // _polygonCollider2D.enabled = true;
        }
        else
        {
            _spriteRenderer.enabled = false;
            // _polygonCollider2D.enabled = false;
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
    }
    
    public void Execute()
    {
        if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep && canBePicked == true && isPointed == true)
        {
            if (isItem == true)
            {
                GameManager.Instance.AddItem(this);
                DisplayItemMark();
                FindObjectOfType<DontDestroyOnLoad>().GameStep++;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
                FindObjectOfType<DontDestroyOnLoad>().GameStep++;
            }
        }
    }

    public void DisplayItemMark()
    {
        _playerController.CanMove = false;
        GameManager.Instance.itemMarkPanel.SetActive(true);
        GameManager.Instance.itemMark.SetActive(true);
        GameManager.Instance.ItemSpriteRenderer.sprite = Itemsprite;
    }
}