using TMPro;
using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameManager gameManager;
    private bool isTakingDamage =false;
    private float damageRate = 10f;
    private Coroutine damageCoroutine;

    void Start()
    {
        currentHealth = maxHealth;
        gameManager.UpdateHealth(currentHealth);

    }
     public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        gameManager.UpdateHealth(currentHealth);
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        gameManager.UpdateHealth(currentHealth);
    }
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        gameManager.UpdateHealth(currentHealth);
    }

    public void StartTakingDamage(float rate)
    {
        if(!isTakingDamage)
        {
            isTakingDamage = true;
            damageRate = rate;
            damageCoroutine = StartCoroutine(DamageOverTime());
        }
    }

    public void StopTakingDamage()
    {
        if (isTakingDamage)
        {
            isTakingDamage = false;
            if(damageCoroutine != null)
                StopCoroutine(damageCoroutine);
        }
    }
    private IEnumerator DamageOverTime()
    {
        while (isTakingDamage)
        {
            TakeDamage((int)damageRate);
            yield return new WaitForSeconds(1f);
        }
    }
}
