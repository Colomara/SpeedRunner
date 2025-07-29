using UnityEngine;

public class ToFaceText : MonoBehaviour
{
    public GameObject canvasToHide; 

    private void Update()
    {
        if (canvasToHide != null && Camera.main != null)
        {
            canvasToHide.transform.LookAt(canvasToHide.transform.position + Camera.main.transform.forward);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canvasToHide != null)
        {
            canvasToHide.SetActive(false);
        }
    }
}