using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field: SerializeField] public string Name { get; private set; }

    public int GameStep;
    public bool isItem;

    public PlayerController _playerController;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Execute()
    {
        if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep)
        {
            if (isItem == true)
            {
                GameManager.Instance.AddItem(this);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        FindObjectOfType<DontDestroyOnLoad>().GameStep++;
    }

    private void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, _playerController.transform.position);

        print(gameObject.name + " : " + dist);
        if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep && dist < 1.5f)
        {
            _spriteRenderer.enabled = true;
        }
        else
        {
            _spriteRenderer.enabled = false;
        }
    }
}