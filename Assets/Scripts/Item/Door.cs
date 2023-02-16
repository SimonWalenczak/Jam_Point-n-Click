using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _nextScene;
    public int GameStep;

    private void Update()
    {
        if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep)
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
        if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep)
        {
            PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
            FindObjectOfType<DontDestroyOnLoad>().GameStep++;
            SceneManager.LoadScene("GameCommon");
        }
    }
}