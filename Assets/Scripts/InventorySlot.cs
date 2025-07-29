using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class InventorySlot : MonoBehaviour
{
    public enum ItemType { None, Healing, SpeedBoost}

    public ItemType itemType = ItemType.None;

    public Image iconImage;
    public bool isOccupied = false;

    public void SetItem(Sprite icon, ItemType type)
    {
        iconImage.sprite = icon;
        iconImage.color = Color.white;
        iconImage.enabled = true;
        isOccupied = true;
        itemType = type;
    }

    public void ClearItem()
    {
        iconImage.sprite = null;
        iconImage.enabled = false;
        isOccupied = false;
    }
    public bool HasItem()
    {
        return isOccupied;
    }

    public void UseItem(PlayerHealth playerHealth, PlayerMovement playerMovement)
    {
        if (!isOccupied) return;

        switch (itemType)
        {
            case ItemType.Healing:
                playerHealth.Heal(50);
                break;

            case ItemType.SpeedBoost:
                playerMovement.ActivateSpeedBoost();
                break;
        }
        ClearItem();
    }

}
