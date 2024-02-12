using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    [SerializeField] private int _hpPower = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponentInChildren<PlayerController>();
        if (controller != null && controller.healthManager.Health < controller.healthManager.MaxHealth)
        {
            controller.PlaySound(collectedClip);
            controller.healthManager.ChangeHealth(_hpPower);
            Destroy(gameObject);
        }
    }
}
