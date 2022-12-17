using DataPersistence;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject errorMessagePanelObj;
    [SerializeField] private GameObject mainMenuPanelObj;
    
    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ContinueButton()
    {
        if(File.Exists(GameDataManager.PersistentPath))
        {
            GameDataManager.Load();
            LoadScene();
        }
        else
        {
            errorMessagePanelObj.SetActive(true);
            mainMenuPanelObj.SetActive(false);
        }
    }

    public void NewGameButton()
    {
        if(File.Exists(GameDataManager.PersistentPath))
        {
            File.Delete(GameDataManager.PersistentPath);
        }
        
        LoadScene();
    }

    public void OkButton()
    {
        errorMessagePanelObj.SetActive(false);
        mainMenuPanelObj.SetActive(true);
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
