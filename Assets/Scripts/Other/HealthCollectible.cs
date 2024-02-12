using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    [SerializeField] private int _hpPower = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.PlaySound(collectedClip);
            controller.ChangeHealth(_hpPower);
            Destroy(gameObject);
        }
    }
}