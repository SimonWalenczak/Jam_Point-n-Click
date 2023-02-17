using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [field: SerializeField] public PlayerController Player { get; private set; }

    public Vector3 spawns;
    [field: SerializeField] public CanvasInventory CanvasInventory { get;  set; }

    public const string NextSceneKey = "NextScene";
    public Texture2D cursorTexture;

    public GameObject itemMarkPanel;
    public GameObject itemMark;
    public SpriteRenderer ItemSpriteRenderer;
    private Vector3 resetPosItemMark;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("WTF");
        }
        
        CanvasInventory = FindObjectOfType<CanvasInventory>();

        resetPosItemMark = itemMark.transform.localEulerAngles;
        
    }
    
    public void ResetPosItemMark()
    {
        itemMark.transform.localEulerAngles = resetPosItemMark;
    }

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        SceneManager.LoadScene(PlayerPrefs.GetString(NextSceneKey, "Scene1"), LoadSceneMode.Additive);
        PlayerPrefs.DeleteKey(NextSceneKey);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosWorld, Vector2.right, 0.01f);

            if (hit.collider != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    interactable.Execute();
                }
            }
        }
    }

    public void AddItem(Item item, Sprite sprite, Sprite sprite2, int type)
    {
        CanvasInventory.AddItem(item, sprite, sprite2, type);
    }
}