using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    [SerializeField] public float timeHealing = 2.0f;
    [SerializeField] private bool isHealing;
    [SerializeField] private float damageCooldown;
    [SerializeField] private int healingPower;

    private void Update()
    {
        if (isHealing)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isHealing = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();


        if (controller != null && !isHealing && controller.health < controller.maxHealth)
        {
            isHealing = true;
            damageCooldown = timeHealing;
            controller.ChangeHealth(healingPower);
        }
    }
}
