
using System.ComponentModel;
using UnityEngine;
using static InventorySlot;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemIcon;
    public ItemType itemType = ItemType.Healing;
    public QuickAccessHandler accessHandler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && accessHandler != null)
        {
            foreach (InventorySlot slot in accessHandler.slots)
            {
                if (!slot.HasItem())
                {
                    slot.SetItem(itemIcon, itemType);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}