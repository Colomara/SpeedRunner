using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public LevelData levelData;
    public GameObject pauseMenu;
    public Button restartButton;
    public Button nextLevelButton;
    public Button quitButton;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI leverCount;
    public Transform playerTransform;
    public float timeLimit;
    private float currentTime;

    private bool isPaused = false;

    public int activatedlevers = 0;
    public int totalLevers;
    public EnemyAI[] enemies;

    public GameObject finishPoint;

    public Lever[] levers;
    public GameObject levelCompletePanel;
    public Animator levelCompleteAnimator;



    //void Awake()
    //{
    //   // DontDestroyOnLoad(this.gameObject);
    //}

    void Start()
    {
        Debug.Log("Level config: " + levelData.leverCount + " levers, " + levelData.enemySpeed + " speed.");
      
        totalLevers = levelData.leverCount;
        timeLimit = levelData.levelTimeLimit;
        foreach (var enemy in enemies)
        {
            enemy.moveSpeed = levelData.enemySpeed;
        }

        pauseMenu.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
        nextLevelButton.onClick.AddListener(LoadNextLevel);
        quitButton.onClick.AddListener(QuitGame);
        finishPoint.SetActive(false);
        currentTime = timeLimit;
        timerText.color = Color.red;
    
    }
    public void ShowLevelComplete()
    {
        levelCompletePanel.SetActive(true);
        StartCoroutine(DelayedTrigger());
    }

    private IEnumerator DelayedTrigger()
    {
        yield return new WaitForEndOfFrame();
        levelCompleteAnimator.SetTrigger("Show");
    }

    // Update is called once per frame
    void Update()
    {

        if (!isPaused)
        {
            if (timerText != null)
            {
                currentTime -= Time.deltaTime;

                timerText.text = "Time Left: " + Mathf.Max(currentTime, 0).ToString("F2");
            }
            if(currentTime <= 0)
            {
                Debug.Log("Time is out!");
                RestartGame();  
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);
            
            if(!isPaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else { Cursor.lockState = CursorLockMode.Confined; }
            Time.timeScale = isPaused ? 0f : 1f;
        }
        
    }

    public void UpdateHealth(int curretHealth)
    {
        healthText.text = "Health: " + curretHealth;

         if (curretHealth <= 30)
        {
            healthText.color = new Color(1f, 0.05f, 0.05f);
        }
        else if (curretHealth <= 60)
        {
            healthText.color = new Color(1f, 0.66f, 0f);
        }
        else
        {
            healthText.color = Color.green;
        }

        if (curretHealth <= 0)
        {
            Debug.Log("You Died!");
            RestartGame();
        }
    }

    void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
        currentTime = timeLimit;
    }

    public void ActivateLever()
    {
        activatedlevers++;
        leverCount.text = "Levers: " + activatedlevers + "/" + totalLevers;
        Debug.Log("lever activated, Total: " + activatedlevers);

        UpdateLevers();

        if(activatedlevers == totalLevers)
        {
            OpenFinishPoint();
        }

    }

    private void UpdateLevers()
    {
        foreach (var lever in levers)
        {
            if(lever.isActivated)
            {
                lever.ChangeColorToGreen();
            }
            else
            {
                lever.ChangeColorToRed();
            }
        }
    }
 

    private void OpenFinishPoint()
    {
        finishPoint.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
        Debug.Log("Finish activated");
      
    }

   public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        currentTime = timeLimit;
    }
    public void QuitGame() => Application.Quit();

}
