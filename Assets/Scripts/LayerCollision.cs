using UnityEngine;

public class LayerExample : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 10;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("LootLayer"))
        {
            Debug.Log("Вы столкнулись с предметом из лута!");
    
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("It`s Enemy!!!");

            playerHealth.TakeDamage(damage);

        }

    }
}