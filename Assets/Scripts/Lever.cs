
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActivated = false;
    public GameManager gameManager;
    public Renderer leverRenderer;
    public Color activatedColor = Color.green;
    
    Animator anim;
    void Start()
    {
       // leverRenderer.material.color = deactivatedColor;
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated) 
        {
            isActivated = true;
            leverRenderer.material.color = activatedColor;
            anim.SetTrigger("Activate");   
            gameManager.ActivateLever(this);
        }
    }
    public void ChangeColorToGreen()
    {
        leverRenderer.material.color = activatedColor;
    }
   
}
