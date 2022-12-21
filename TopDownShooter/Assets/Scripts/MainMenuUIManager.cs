using System.IO;
using DataPersistence;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        if(File.Exists(Application.persistentDataPath + "/" + "topdownshooter.game"))
        {
            continueButton.interactable = true;
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ContinueButton()
    {
        LoadScene();
    }

    public void NewGameButton()
    {
        DataPersistenceManager.Instance.NewGame();
        LoadScene();
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
        #else
                 Application.Quit();
        #endif
    }
}
