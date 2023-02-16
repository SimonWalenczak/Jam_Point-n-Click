using System;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public int GameStep = 0;
    [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
    [field: SerializeField] public List<Sprite> BackgroundSprite { get; private set; }
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        _backgroundSpriteRenderer.sprite = BackgroundSprite[GameStep];

        GameObject[] dontdestroyonloadObjects = GameObject.FindGameObjectsWithTag("DDOL");

        if (dontdestroyonloadObjects.Length > 1)
        {
            Destroy(dontdestroyonloadObjects[1]);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameStep++;
        }
    }
}