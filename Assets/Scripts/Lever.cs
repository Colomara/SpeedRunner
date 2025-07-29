
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActivated = false;
    public GameManager gameManager;
    public Renderer leverRenderer;
    public Color activatedColor = Color.green;
    public Color deactivatedColor = Color.red;
    void Start()
    {
        leverRenderer.material.color = deactivatedColor;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            leverRenderer.material.color = activatedColor;
            gameManager.ActivateLever();
            Debug.Log("Activated");
          //  Destroy(gameObject);
        }
    }
    public void ChangeColorToGreen()
    {
        leverRenderer.material.color = activatedColor;
    }
    public void ChangeColorToRed()
    {
        leverRenderer.material.color= deactivatedColor;
    }
}
