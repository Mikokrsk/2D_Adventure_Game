using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] public InputAction MoveAction;
    [SerializeField] public InputAction launchAction;
    [SerializeField] public InputAction talkAction;
    [SerializeField] private Vector2 move;
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Vector2 moveDirection = new Vector2(1, 0);
    [SerializeField] public int maxHealth = 5;
    [SerializeField] public float speed = 3.0f;
    [SerializeField] public int currentHealth;

    [SerializeField] public float timeInvincible = 2.0f;
    [SerializeField] private bool isInvincible;
    [SerializeField] private float damageCooldown;
    public int health { get { return currentHealth; } }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        MoveAction.Enable();
        launchAction.Enable();
        talkAction.Enable();
        launchAction.performed += Launch;
        talkAction.performed += FindFriend;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }
        animator.SetFloat("Move X", moveDirection.x);
        animator.SetFloat("Move Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }


    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
            animator.SetTrigger("Hit");
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
    }

    void Launch(InputAction.CallbackContext context)
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(moveDirection, 300);
        projectile.startPosition = transform.position;
        animator.SetTrigger("Launch");
    }
    void FindFriend(InputAction.CallbackContext context)
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            Debug.Log("Raycast has hit the object " + hit.collider.gameObject);

            NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
            if (character != null)
            {
                character.DisplayDialogue();
                // UIHandler.instance.DisplayDialogue();
            }


        }
    }
}
