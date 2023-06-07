using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    private Transform _positionToSpawn;
    [SerializeField] private float delay = 0.5f, bulletForce = 10f;
    
    private float _timer;
    private bool _isDown;
    void Start()
    {
        _isDown = false;
        _timer = 0f;
        _positionToSpawn = FindObjectOfType<PlayerController>().BulletSpawn;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_isDown && _timer > delay)
        {
            Shoot();
            _timer = 0f;
        }
    }

    public void Shoot()
    {
        Rigidbody2D bullet = Instantiate(bulletPrefab, _positionToSpawn.position, _positionToSpawn.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        bullet.AddForce(_positionToSpawn.up * bulletForce, ForceMode2D.Impulse);
    }

    public void FireButtonDown()
    {
        _isDown = true;
    }
    public void FireButtonUp()
    {
        _isDown = false;
    }
}