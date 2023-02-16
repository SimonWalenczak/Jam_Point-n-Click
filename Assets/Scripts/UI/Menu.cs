using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _credtisPanel;
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameCommon");
    }

    public void OnClickQuit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnClickOpenCredits()
    {
        _credtisPanel.SetActive(true);
    }
    
    public void OnClickCloseCredits()
    {
        _credtisPanel.SetActive(false);
    }
}