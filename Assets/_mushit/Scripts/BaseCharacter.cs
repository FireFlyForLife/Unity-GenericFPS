using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour, Damageable {
    public int Health {
        get {
            return _health;
        }
        set {
            _health = value;
            if (_health <= 0)
                OnDeath();
        }
    }
    private int _health = 100;

    public bool IsDead() { return Health <= 0; }

    virtual protected void OnDeath() { }

    public void Damage(int amount)
    {
        Health -= amount;
    }
}
