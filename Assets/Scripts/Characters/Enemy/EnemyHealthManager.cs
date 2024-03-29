using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    //  [SerializeField] private EnemyController _enemyController;

    [SerializeField] public float timeInvincible = 2.0f;
    [SerializeField] public bool isInvincible;
    [SerializeField] private float damageCooldown;

    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            UpdateHpBar();
        }
    }

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
            UpdateHpBar();
        }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }

    public void Heal(int healValue)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + healValue, 0, _maxHealth);
        UpdateHpBar();
    }

    public void GetHit(int damage)
    {
        if (isInvincible)
        {
            return;
        }
        isInvincible = true;
        damageCooldown = timeInvincible;
        // _enemyController.animator.SetTrigger("Hit");
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        UpdateHpBar();
        if (_currentHealth <= 0)
        {
            Death();
        }
    }
    public void UpdateHpBar()
    {
        // GameUI.Instance.SetHealthValue(_currentHealth / (float)_maxHealth);
        Debug.Log($"Update HpBar {this.name}");
    }
    public void Death()
    {
        Debug.Log($"Enemy {this.name} Death");
        Destroy(gameObject);
    }
}
