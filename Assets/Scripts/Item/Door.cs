using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _nextScene;

    public int GameStep;

    public void Execute()
    {
        if (GameStep == FindObjectOfType<DontDestroyOnLoad>().GameStep)
        {
            PlayerPrefs.SetString(GameManager.NextSceneKey, _nextScene);
            SceneManager.LoadScene("GameCommon");
        }
    }
}