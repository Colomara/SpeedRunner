
//using UnityEngine;

//public class FinishTrigger : MonoBehaviour
//{

//    public GameObject levelCompletePanel;


//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            levelCompletePanel.SetActive(true);
//            Time.timeScale = 0f;

//        }
//    }
//}

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
            gameManager.ShowLevelComplete();
            Time.timeScale = 0f;
        }
    }
}