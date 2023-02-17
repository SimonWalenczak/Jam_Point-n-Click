using System.Collections.Generic;
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
    }
}