using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthManager
{
    public int Health { get; set; }
    public int MaxHealth { get; }

    public void ChangeHealth(int amound)
    {

    }
    public void Death()
    {

    }
}