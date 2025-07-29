using UnityEngine;

public class QuickAccessHandler : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public InventorySlot[] slots;
    public PlayerHealth playerHealth;

    void Update()
    {
       for (int i = 0; i < slots.Length; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                if (slots[i].HasItem())
                {
                    slots[i].UseItem(playerHealth, playerMovement);
                }
            }
        }
       
    }
}