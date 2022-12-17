using DataPersistence;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameUIPanelObj;
    [SerializeField] private GameObject pauseMenuPanelObj;

    private void Awake()
    {
        gameUIPanelObj.SetActive(true);
        pauseMenuPanelObj.SetActive(false);
        Time.timeScale = 1f;
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void ExitButton()
    {
        GameDataManager.Save();
        LoadScene();
    }

    public void PauseButton()
    {
        gameUIPanelObj.SetActive(false);
        pauseMenuPanelObj.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void ResumeButton()
    {
        gameUIPanelObj.SetActive(true);
        pauseMenuPanelObj.SetActive(false);
        Time.timeScale = 1;
    }
}
