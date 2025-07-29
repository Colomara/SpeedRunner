
using UnityEngine;
using UnityEngine.UI;

public class HotBarUI : MonoBehaviour
{
    public Image[] slotImages;

    public void AddItem(Sprite itemSprite)
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (slotImages[i].sprite == null)
            {
                slotImages[i].sprite = itemSprite;
                slotImages[i].color = Color.white;
                break;
            }
        }
    }
}
