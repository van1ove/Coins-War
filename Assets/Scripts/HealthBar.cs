using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image _healthImage;
    // private readonly float maxHealth = 100f;
    // public float Hp { get; set; }
    void Start()
    {
        _healthImage = GetComponent<Image>();
    }
    public void ChangeHealth(float value)
    {
        _healthImage.fillAmount = value;
    }
}
