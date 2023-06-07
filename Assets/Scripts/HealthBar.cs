using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image _healthImage;
    private float _maxHealth = 100f;
    public float _hp = 100f;
    void Start()
    {
        _healthImage = GetComponent<Image>();
        _hp = 100f;
    }
    void Update()
    {
        _healthImage.fillAmount = _hp / _maxHealth;
    }
}
