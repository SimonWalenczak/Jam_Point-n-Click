using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _nextScene;
    public int GameStep1;
    public int GameStep2;

    private float dist;
    [SerializeField] private bool isPointed;
    [SerializeField] private bool canBePicked;
    public PlayerController _playerController;
    [SerializeField] private float distDetect;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private void OnMouseEnter()
    {
        isPointed = true;
    }

    private void OnMouseExit()
    {
        isPointed = false;
    }
    
    private void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, _playerController.transform.position);
        
        if (dist < distDetect)
        {
            canBePicked = true;
        }
        else
        {
            canBePicked = false;
        }
        
        if (FindObjectOfType<DontDestroyOnLoad>().GameStep == GameStep1 || FindObjectOfType<DontDestroyOnLoad>().GameStep == GameStep2)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void Execute()
    {
        if ((FindObjectOfType<DontDestroyOnLoad>().GameStep == GameStep1 || FindObjectOfType<DontDestroyOnLoad>().GameStep == GameStep2) && canBePicked == true && isPointed == true)
        {
            PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
            FindObjectOfType<DontDestroyOnLoad>().GameStep++;
            SceneManager.LoadScene("GameCommon");
        }
    }
}