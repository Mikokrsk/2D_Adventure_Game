using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponentInChildren<PlayerController>();


        if (controller != null)
        {
            controller.healthManager.GetHit(_damage);
        }
    }
}