
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined; 
            gameManager.ShowLevelComplete();
            Time.timeScale = 0f;
        }
    }
}