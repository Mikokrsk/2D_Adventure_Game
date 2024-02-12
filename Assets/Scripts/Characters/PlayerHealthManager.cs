using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IHealthManager
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private PlayerController _playerController;

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
            ChangeHealth(value);
        }
    }

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
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
           _playerController.animator.SetTrigger("Hit");
        }
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
        GameUI.Instance.SetHealthValue(_currentHealth / (float)_maxHealth);
        if(_currentHealth<=0)
        {
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("Death");
    }
}
