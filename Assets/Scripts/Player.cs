using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HealthBar _healthBar;
    //private PlayerController _playerController;
    private readonly float maxHealth = 100f;
    private float _health = 100f;
    void Start()
    {
        //_playerController = GetComponent<PlayerController>();
        _healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 7)
        {
            _health -= 10f;
            float hp = _health / maxHealth;
            _healthBar.ChangeHealth(hp);
        }
    }
}
