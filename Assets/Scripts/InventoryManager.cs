
//using UnityEngine;

//public class InventoryManager : MonoBehaviour
//{
//    public InventorySlot[] slots;
//    public PlayerHealth playerHealth;

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {
//            TryUseItem(0);
//        }
//    }

//    void TryUseItem(int slotIndex)
//    {
//        if(slotIndex < slots.Length && slots[slotIndex].HasItem())
//        {
//            playerHealth.Heal(50);
//            slots[slotIndex].ClearItem(); 
//        }
//    }
//}
