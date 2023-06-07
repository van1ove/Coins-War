using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public float lifetime = 5f;
    private float _timer;

    private void Start()
    {
        _timer = 0f;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= lifetime)
        {
            Destroy(bullet);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        
    }
}