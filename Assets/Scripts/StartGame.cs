using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public Button nextLevelButton;
    public Button quitButton;
    public Button infoButton;
    public Button closeInfoButton;
    public GameObject panelInfo;
    
    void Start()
    {
        nextLevelButton?.onClick.AddListener(() => LoadNextLevel());
        quitButton?.onClick.AddListener(() => QuitGame());
        infoButton?.onClick.AddListener(() => ToggleInfoPanel(true));
        closeInfoButton?.onClick.AddListener(() => ToggleInfoPanel(false));
        panelInfo.SetActive(false);
    }


    public void LoadNextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   
    public void ToggleInfoPanel(bool state) => panelInfo.SetActive(state);
    
    public void QuitGame() => Application.Quit();
    
        
    
}
