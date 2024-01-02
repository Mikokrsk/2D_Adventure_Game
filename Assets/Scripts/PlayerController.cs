using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] public InputAction MoveAction;
    [SerializeField] private Vector2 move;
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] public int maxHealth = 5;
    [SerializeField] public float speed = 3.0f;
    [SerializeField] public int currentHealth;
    public int health { get { return currentHealth; } }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
    }


    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
