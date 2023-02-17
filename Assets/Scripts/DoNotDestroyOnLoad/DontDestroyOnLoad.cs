using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public int GameStep = 0;
    [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;

    [field: SerializeField] public List<Sprite> BackgroundSprite { get; private set; }
    
    public bool haveShovel;
    public bool haveEye;
    public bool haveBattery;
    public bool haveSkull;

    public bool giftSkull;
    public GameObject DialogPanel;
    public string _dialog;
    [SerializeField] private bool finishDialog;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ResetBoolAction()
    {
        haveShovel = false;
        haveEye = false;
        haveBattery = false;
        haveSkull = false;
    }
    
    private void Update()
    {
        
        _backgroundSpriteRenderer.sprite = BackgroundSprite[GameStep];

        GameObject[] dontdestroyonloadObjects = GameObject.FindGameObjectsWithTag("DDOL");

        if (dontdestroyonloadObjects.Length > 1)
        {
            Destroy(dontdestroyonloadObjects[1]);
        }
        
        if (GameStep == 13)
        {
            DialogPanel.SetActive(true);
            if (giftSkull == true && Input.GetMouseButtonDown(0)) // condition crane poupée
            {
                if (finishDialog == false)
                {
                    DialogPanel.GetComponentInChildren<TextMeshProUGUI>().SetText(_dialog);
                    finishDialog = true;
                }
                else
                {
                    GameStep++;
                }
            }
            
        }

        if (GameStep == 14)
        {
            DialogPanel.SetActive(false);
        }
    }
}