using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDamageZone : MonoBehaviour
{
    public float damagePerSecond = 10f;
    public float slowMultiplier = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            PlayerHealth health = other.GetComponent<PlayerHealth>();

            if (movement != null)
                movement.SetSpeedMultiplier(slowMultiplier);

            if (health != null)
                health.StartTakingDamage(damagePerSecond);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement movement = other.GetComponent<PlayerMovement>();
            PlayerHealth health = other.GetComponent<PlayerHealth>();

            if (movement != null)
                movement.SetSpeedMultiplier(1f);

            if (health != null)
                health.StopTakingDamage();
        }
    }
}
