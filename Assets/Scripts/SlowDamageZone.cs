using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDamageZone : MonoBehaviour
{
    public float damagePerSecond = 10f;
    public float slowMultiplier = 0.5f;
    const string SfxName = "foot-stepping-on-thin-ice-290822";

    private void OnTriggerEnter (Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.GetComponent<PlayerMovement>()?.SetSpeedMultiplier (slowMultiplier);
        other.GetComponent<PlayerHealth>()?.StartTakingDamage(damagePerSecond);

        AudioManager.Instance.PlaySFX(SfxName, 0.8f);
     
    }


    private void OnTriggerExit (Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.GetComponent<PlayerMovement>()?.SetSpeedMultiplier(1f);
        other.GetComponent<PlayerHealth>()?.StopTakingDamage();
        AudioManager.Instance.StopLoop();
      
    }
}
